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
using System.Net.Mail;
using System.Net.Mime;
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
                string serverFolder="";
                if (contactU.AttechmentFile != null)
                {
                    string folder = "ContactUsFile/";
                    folder += Guid.NewGuid().ToString() + "_" + contactU.AttechmentFile.FileName;
                   serverFolder = Path.Combine(_WebHostEnvironment.WebRootPath, folder);
                    var file = new FileStream(serverFolder, FileMode.Create);
                    contactU.AttechmentFile.CopyToAsync(file);
                    contactU.FileName = folder;
                    file.Close();
                  
                }


                contactU.CreatedOn = DateTime.Now;
               var contacUtId= _db.ContactUs.Add(contactU);
                _db.SaveChanges();

                string message = "<p> user name :- "+contactU.FirstName+" "+contactU.LastName+" </p>"+"<p>mobile number :- "+contactU.PhoneNumber+" </p>"+"<p>email :- "+contactU.Email+"</p>"+ "<p>query type :- "+contactU.Subject+"</p>"+"<p> message :- "+contactU.Message+"</p>"+"createdBy :- "+ contactU.CreatedBy +"</p><p> createOn :- "+contactU.CreatedOn+"</p>";
                List<User> AdminList = _db.Users.Where(x => x.UserTypeId == 3).ToList();
                if (AdminList.Count() > 0)
                {
                    ContactU contact = _db.ContactUs.FirstOrDefault(x => x.ContactUsId == contacUtId.Entity.ContactUsId);

                    Task task = Task.Run(() => SendMain(AdminList, message, serverFolder, contact));
                }

                return RedirectToAction("Contact","Home",new {ContactModal = "true"});


            }
            else
            {
                return PartialView();
            }
        }

        private static void SendMain(List<User> AdminList, string message,string path,ContactU contact)
        {
            
            SmtpClient setup = new SmtpClient("smtp.gmail.com");
            setup.Port = 587;
            setup.UseDefaultCredentials = true;
            setup.EnableSsl = true;
            setup.Credentials = new System.Net.NetworkCredential("kripcsarvaiya@gmail.com", "9825106734");

            string subject = "New Service Request ";
            string body = message;
            MailMessage mm = new MailMessage();
            mm.Subject = subject;
            mm.Body = body;
            if (path != "")
            {
                Attachment attachment;
                attachment = new Attachment(path,new ContentType("image/png"));
                mm.Attachments.Add(attachment);
            }
            mm.From = new MailAddress("kripcsarvaiya@gmail.com");
            mm.IsBodyHtml = true;
            foreach (var obj in AdminList)
            {
                string to = obj.Email;

                mm.To.Add(to);




            }
            setup.Send(mm);
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
