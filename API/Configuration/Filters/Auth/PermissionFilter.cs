﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using System.Linq;


namespace API.Configuration.Filters.Auth
{

    public class PermissionFilter: IAuthorizationFilter
    {
        private readonly Permission _permission;
        public PermissionFilter(Permission permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {


            var cacheClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserPermissionAddCache");
            if (cacheClaim == null)
                context.Result = new BadRequestResult();


            var cacheManager = context.HttpContext.RequestServices.GetService<IDistributedCache>();
            //var cacheManager2 =(context.HttpContext.RequestServices.GetService(typeof(IDistributedCache))) as IDistributedCache;

            var strCachePermissions = cacheManager.GetString(cacheClaim.Value);

            if (string.IsNullOrWhiteSpace(strCachePermissions))
            {
                context.Result = new ForbidResult("Bu metoda yetkiniz yok");
            }
            else
            {
                var cachePermissionList =
                    System.Text.Json.JsonSerializer.Deserialize<Permission[]>(strCachePermissions);

                if (!cachePermissionList.Any(x => x == _permission))
                    context.Result = new ForbidResult("Bu metoda yetkiniz yok");
            }
        }
    }
}
