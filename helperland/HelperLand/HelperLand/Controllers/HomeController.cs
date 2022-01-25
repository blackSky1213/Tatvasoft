using HelperLand.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return PartialView();
        }

        public IActionResult About()
        {
            return PartialView();
        }

        public IActionResult Price()
        {
            return PartialView();
        }

        public IActionResult Faq()
        {
            return PartialView();
        }

        public IActionResult Contact()
        {
            return PartialView();
        }

        public IActionResult BecomePro()
        {
            return PartialView();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
