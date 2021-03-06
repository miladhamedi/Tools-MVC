﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ManualAuthenticationSample.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManualAuthenticationSample.Areas.Admin.Controllers
{
    public class CustomGeneratorController : BaseController
    {
        private FadContext _context;

        public CustomGeneratorController(FadContext context)
        {
            _context = context;
        }

        #region actions

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GeneratePermissions()
        {
            var permissionList = new List<Permissions>();

            //لیست دسترسی های موجود در دیتابیس
            var oldPremissionList = await _context.Permissions.ToListAsync();

            //لیست کنترلرها
            var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.BaseType == typeof(Areas.Admin.Controllers.BaseController));
            foreach (var controller in controllers)
            {
                //لیست اکشن های یک کنترلر
                var actions = controller.GetMethods().Where(q => q.IsPublic && q.DeclaringType.FullName == controller.FullName);
                foreach (var action in actions)
                {
                    //چک کردن اینکه از قبل در دیتابیس وجود نداشته باشد
                    if (!oldPremissionList.Any(q => q.AreaName == controller.FullName && q.ActionName == action.Name && q.ActionType == GetActionType(action)))
                    {
                        var permission = new Permissions
                        {
                            ActionName = action.Name,
                            ControllerName = controller.Name,
                            ControllerCaption = controller.Name,
                            ActionCaption = $"{controller.Name}-{action.Name}",
                            ActionType = GetActionType(action),
                            AreaName = controller.FullName,
                        };
                        permissionList.Add(permission);
                    }
                }
            }
            await _context.AddRangeAsync(permissionList);
            await _context.SaveChangesAsync();
            return View();
        }

        private byte GetActionType(MethodInfo action)
        {
            foreach (var attribute in action.CustomAttributes)
            {
                var attributeName = attribute.AttributeType.Name;
                switch (attributeName)
                {
                    case "HttpGetAttribute":
                        return (byte)ControllerActionType.Get;
                    case "HttpPostAttribute":
                        return (byte)ControllerActionType.Post;
                    case "HttpPutAttribute":
                        return (byte)ControllerActionType.Put;
                    case "HttpDeleteAttribute":
                        return (byte)ControllerActionType.Delete;
                }
            }


            return 1;
        }

        public enum ControllerActionType
        {
            Get = 1,
            Post = 2,
            Put = 3,
            Delete = 4,
        }

        #endregion
    }
}