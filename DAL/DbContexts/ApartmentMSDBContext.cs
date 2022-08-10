using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace DAL.DbContexts
{
    public  class ApartmentMSDBContext:DbContext
    { 
        private IConfiguration _configuration;
        public ApartmentMSDBContext(IConfiguration configuration)
        {
           
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UsersPassswords { get; set; }
        //public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<UtilityBill> UtilityBills { get; set; }
        public DbSet<UtilityBillType> UtilityBillTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("MsComm");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}

