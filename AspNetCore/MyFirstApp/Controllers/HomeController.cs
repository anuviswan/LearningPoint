using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstApp.Models;
using MyFirstApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILog _consoleLogger;

        public HomeController(ILogger<HomeController> logger,ILog consoleLogger)
        {
            _logger = logger;
            _consoleLogger = consoleLogger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
