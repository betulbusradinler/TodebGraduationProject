using API.Configuration.Filters.Exception;
using API.Configuration.Filters.Logs;
using Business.Abstract;
using Business.Concrete;
using Business.Configuration.Auth;
using Business.Configuration.Cache;
using Business.Configuration.Mapper;
using Bussines.Abstract;
using Bussines.Concrete;
using DAL.Abstract;
using DAL.Concrete.EF;
using DAL.Concrete.Mongo;
using DAL.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Uygulama build olup ayaða kalkýncaya kadar gerekli ayarlamalarý yapan yer.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApartmentMSDBContext>(ServiceLifetime.Transient); // Her Db Context çaðrýldýðýnda bu benim için sistem tarafýndan new lenecek
            var redisConfigInfo = Configuration.GetSection("RedisEndpointInfo").Get<RedisEndpointInfo>();
            // User DI
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserPasswordRepository, EFUserPasswordRepository>();
            services.AddScoped<IUserPasswordService, UserPasswordService>();

            services.AddScoped<IAuthService, AuthService>();
            // Flat DI
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<IFlatRepository,EFFlatRepository>();
            //UtilityBill
            services.AddScoped<IUtilityBillService, UtilityBillService>();
            services.AddScoped<IUtilityBillRepository, EFUtilityBillRepository>();
            //UtilityBillType
            services.AddScoped<IUtilityBillTypeService, UtilityBillTypeService>();
            services.AddScoped<IUtilityBillTypeRepository, EFUtilityBillTypeRepository>();
            //Chat
            services.AddScoped<IChatRepository, EFChatRepository>();
            services.AddScoped<IChatService, ChatService>();

            //Tüm dairelere tek seferde fatura atama 
            services.AddScoped<IChatRepository, EFChatRepository>();

            services.AddScoped<IOneTimeBillingForAllFlatsService, OneTimeBillingForAllFlatsService>();
            services.AddScoped<IOneTimeBillingForAllFlatsRepository, EFOneTimeBillingForAllFlatsRepository>();
            //mongoDb
            services.AddSingleton<MongoClient>(x => new MongoClient("mongodb://localhost:27017"));
            services.AddScoped<ICrediCartRepository, CreditCardRepository>();
            services.AddScoped<ICreditCardService, CreditCardService>();
            services.AddSingleton<MsSqlLogger>();

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.ConfigurationOptions = new ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { redisConfigInfo.EndPoint, redisConfigInfo.Port }
                    },
                    Password = redisConfigInfo.Password,
                    User = redisConfigInfo.UserName

                };
            });
            services.AddMemoryCache();


            services.AddScoped<ICacheExample, CacheExample>();

            // Token ayarý
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOption>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                    };
                });


            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Uygulama ayaða kalktýktan sonra aþaðýdaki ayarlarý uygular.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }


            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>().Error;

                var jsonResult = new JsonResult(
                   new
                   {
                       error = exception.Message,
                       innerException = exception.InnerException,
                       statusCode = HttpStatusCode.InternalServerError
                   }

               );
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(jsonResult);
            }));





            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
