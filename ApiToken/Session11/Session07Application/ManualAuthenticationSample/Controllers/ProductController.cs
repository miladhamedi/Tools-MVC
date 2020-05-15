using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManualAuthenticationSample.Controllers
{
    public class ProductController : Controller
    {
        IWebHostEnvironment _env;
        public ProductController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile thumbnail)
        {
            var f = thumbnail;

            var newFileName = DateTime.Now.Ticks;
            var tempArray = thumbnail.FileName.Split('.');
            var fileExtension =tempArray[tempArray.Length - 1];

            var fileName = $"{newFileName}.{fileExtension}";
            var basePath = $"{_env.WebRootPath}\\Medias\\Products\\";
            var filePath = $"{basePath}/{fileName}";

            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            //save in file
            using (var stream = System.IO.File.Create(filePath))
            {
                await thumbnail.CopyToAsync(stream);
            }

            return View("Index");
        }
    }
}