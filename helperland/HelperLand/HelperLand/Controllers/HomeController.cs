using HelperLand.Data;
using HelperLand.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        private readonly HelperlandContext _db;
        private readonly IWebHostEnvironment _WebHostEnvironment;

        public HomeController(HelperlandContext db, IWebHostEnvironment WebHostEnvironment)
        {
            _WebHostEnvironment = WebHostEnvironment;
            _db = db;
        }

        public IActionResult Index()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                ViewBag.Name = obj;
               
            }else if (Request.Cookies["userid"] != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userid"]));
                ViewBag.Name = obj;
                return PartialView();
            }

            return PartialView();
        }

        public IActionResult About()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                ViewBag.Name = obj;

            }
            else if (Request.Cookies["userid"] != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userid"]));
                ViewBag.Name = obj;
                return PartialView();
            }
            return PartialView();
        }

        public IActionResult Price()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                ViewBag.Name = obj;

            }
            else if (Request.Cookies["userid"] != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userid"]));
                ViewBag.Name = obj;
                return PartialView();
            }
            return PartialView();
        }

        public IActionResult Faq()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                ViewBag.Name = obj;

            }
            else if (Request.Cookies["userid"] != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userid"]));
                ViewBag.Name = obj;
                return PartialView();
            }
            return PartialView();
        }

        public IActionResult Contact()
        {
            
                int? Id = HttpContext.Session.GetInt32("id");
                if (Id != null)
                {
                    User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                    ViewBag.Name = obj;

                }
                else if (Request.Cookies["userid"] != null)
                {
                    User obj = _db.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userid"]));
                    ViewBag.Name = obj;
                    return PartialView();
                }
           
                return PartialView();
            
            
           
        }

        [HttpPost]
        public IActionResult Contact(ContactU contactU)
        {
            if (ModelState.IsValid)
            {
                var Id = HttpContext.Session.GetInt32("id");
                if (Id != null)
                {
                    ViewBag.Name = Id;
                }
                if (contactU.AttechmentFile != null)
                {
                    string folder = "ContactUsFile/";
                    folder += Guid.NewGuid().ToString() + "_" + contactU.AttechmentFile.FileName;
                    string serverFolder = Path.Combine(_WebHostEnvironment.WebRootPath, folder);
                    contactU.AttechmentFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    contactU.FileName = folder;
                }


                contactU.CreatedOn = DateTime.Now;
                _db.ContactUs.Add(contactU);
                _db.SaveChanges();
                return RedirectToAction("Contact","Home",new {ContactModal = "true"});


            }
            else
            {
                return PartialView();
            }
        }

       

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
