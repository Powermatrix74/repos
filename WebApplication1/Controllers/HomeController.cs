using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyWebAppGit.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PictureOverview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PictureOverview(PictureInformation result)
        {
            if (result != null)
            {
                try
                {
                    var optionsBuilder = new DbContextOptionsBuilder<PictureDatabaseContext>();
                    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PictureDatabase"));

                    using (PictureDatabaseContext context = new PictureDatabaseContext(optionsBuilder.Options))
                    {

                        context.Add(result);
                        context.SaveChanges(true);
                    }
                }
                catch { }
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
