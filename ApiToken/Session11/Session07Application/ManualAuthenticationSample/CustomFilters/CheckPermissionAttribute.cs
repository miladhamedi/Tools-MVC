using ManualAuthenticationSample.Common;
using ManualAuthenticationSample.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualAuthenticationSample.CustomFilters
{
    public class CheckPermissionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {


            var areaName = context.RouteData.Values["area"].ToString();
            var actionName = context.RouteData.Values["action"].ToString();
            var controllerName = context.RouteData.Values["controller"] + "Controller";
            //get-post-put-delete
            var actionType = context.HttpContext.Request.Method;

            var userName = context.HttpContext.User.Identity.Name;
            var roles = context.HttpContext.User.Claims.
                SingleOrDefault(q => q.Type == "Role").Value.Split(',').ToList().Select(q => Convert.ToInt32(q));


            //create instance from DbContext
            //Inject with resolver
            var dbContext = context.HttpContext.RequestServices.GetService(typeof(FadContext)) as FadContext;
            var _cache = context.HttpContext.RequestServices.GetService(typeof(IMemoryCache)) as IMemoryCache;
            var key = string.Format(CacheConstants.UserPermissionsCacheKey, userName);

            List<Permissions> userPermissions;
            if (!_cache.TryGetValue<List<Permissions>>(key, out userPermissions))
            {
                userPermissions =
                  dbContext.Permissions.Where(q => q.RolePermissions.Any(r => roles.Contains(r.RoleId))).ToList();
                _cache.Set(key, userPermissions);
            }
            var allowPermissions = userPermissions.Any(q => q.AreaName.ToLower() == areaName.ToLower()
        && q.ControllerName.ToLower() == controllerName.ToLower() && q.ActionName.ToLower() == actionName.ToLower());


            //if (!_cache.TryGetValue<List<Permissions>>())
            //      dbContext.RolePermissions.Where(q => roles.Contains(q.RoleId) &&
            //      q.Permission.AreaName == areaName && q.Permission.ControllerName == controllerName &&
            //      q.Permission.ActionName == actionName);


            //var allowPermissions = dbContext.RolePermissions.Any(q => roles.Contains(q.RoleId) &&
            //     q.Permission.AreaName == areaName && q.Permission.ControllerName == controllerName &&
            //     q.Permission.ActionName == actionName);

            if (allowPermissions)
            {
                base.OnActionExecuting(context);
            }
            else
            {

                context.Result = new RedirectResult("/Error/NotAllowed");
            }


            //using (var dbContext = new FadContext())
            //{
            //    var allowPermissions = 
            //        dbContext.RolePermissions.Any(q => roles.Contains(q.RoleId) && 
            //        q.Permission.AreaName == areaName && q.Permission.ControllerName == controllerName && 
            //        q.Permission.ActionName == actionName);

            //    if(allowPermissions)
            //    {
            //        base.OnActionExecuting(context); 
            //    } else
            //    {

            //        context.Result = new RedirectResult("/Error/NotAllowed");
            //    }
            //}



            //check user permissions from db




        }
    }
}
