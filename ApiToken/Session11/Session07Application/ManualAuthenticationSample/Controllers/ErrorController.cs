using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ManualAuthenticationSample.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotAllowed()
        {
            return View();
        }

    }
}