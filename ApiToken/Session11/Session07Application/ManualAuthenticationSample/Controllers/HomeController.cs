using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManualAuthenticationSample.Models;
using Microsoft.AspNetCore.Authorization;
using ManualAuthenticationSample.Common;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using ManualAuthenticationSample.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ManualAuthenticationSample.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConnectionStrings _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, IOptions<ConnectionStrings> options,
            IConfiguration configuration, IHubContext<ChatHub> hubcontext)
        {
            _logger = logger;
            _connectionString = options.Value;
            _configuration = configuration;
            _hubContext = hubcontext;
        }

        //بازدید برای عموم آزاد است
        [AllowAnonymous]
        public IActionResult Index()
        {
            var test = _connectionString.FAdConnection;
            _logger.LogDebug(test);
            ViewData["test"] = test;

            ViewData["test2"] = _configuration.GetConnectionString("FAdConnection");

            return View();
        }

        public IActionResult SendAdminMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendAdminMessage(string message)
        {
            await this._hubContext.Clients.All.SendAsync("adminMessage", message);
            //await context.Clients.All.SendAsync("adminMessage", message);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
