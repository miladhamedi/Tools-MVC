using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManualAuthenticationSample.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManualAuthenticationSample.Areas.Admin.Controllers
{
    [Authorize]
    [CheckPermission]
    [Area("Admin")]
    public class BaseController : Controller
    {
    }
}