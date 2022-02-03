using HelperLand.Data;
using HelperLand.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HelperLand.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly HelperlandContext _db;

        public RegistrationController(HelperlandContext db)
        {
            _db = db;
        }
        public IActionResult SignUp()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(User user)
        {           
                if (ModelState.IsValid)
                {
                if (_db.Users.Where(x => x.Email == user.Email).Count() == 0 && _db.Users.Where(x => x.Mobile == user.Mobile).Count() == 0)
                {
                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.IsRegisteredUser = true;
                    user.ModifiedBy = 123;

                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "User already exist.";
                    return PartialView();
                }
            }               
            return PartialView();

        }

        public IActionResult BecomePro()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BecomePro(User user)
        {
            if (ModelState.IsValid)
            {
                if ((_db.Users.Where(x => x.Email == user.Email).Count() == 0 && _db.Users.Where(x => x.Mobile == user.Mobile).Count() == 0) )
                {
                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.IsRegisteredUser = true;
                    user.ModifiedBy = 123;
                      
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "User already exist.";
                    return PartialView();
                }
            }
            return PartialView();

           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AuthLogin user)
        {
            if (ModelState.IsValid)
            {
                if (_db.Users.Where(x => x.Email == user.username && x.Password == user.password).Count() > 0)
                {

                    var U = _db.Users.FirstOrDefault(x => x.Email == user.username);
                    HttpContext.Session.SetInt32("id",U.UserId);
                   
                    return RedirectToAction("CustomerServiceHistory", "Customer");
                }
                else
                {
                    TempData["add"] = "alert show";
                    TempData["fail"] = "username and password are invalid";
                    return RedirectToAction("Index", "Home", new { loginModal = "true" });

                }
            }

            return RedirectToAction("Index", "Home", new { loginModal = "true" });





        }
        
        public IActionResult CustomerServiceHistory()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgetPass(ForgetPass user)
        {
            if(_db.Users.Where(x=> x.Email == user.email).Count() > 0)
            {
                int Id = _db.Users.FirstOrDefault(x => x.Email == user.email).UserId;
                string to = user.email;
                string subject = "Reset password";
                string body = "<p>Reset your password by click below link " +
                    "<a href='" + Url.Action("ResetPassword", "Registration",new { userid=Id} , "https") + "'>Reset Password</a></p>"; 
                MailMessage mm = new MailMessage();
                mm.To.Add(to);
                mm.Subject = subject;
                mm.Body = body;
                mm.From = new MailAddress("kripcsarvaiya@gmail.com");
                mm.IsBodyHtml = true;
                SmtpClient setup = new SmtpClient("smtp.gmail.com");
                setup.Port = 587;
                setup.UseDefaultCredentials = true;
                setup.EnableSsl = true;
                setup.Credentials = new System.Net.NetworkCredential("User_name", "Password");
                setup.Send(mm);

                TempData["add"] = "alert show alert-success";
                TempData["message"] = "mail successfully!";
                return RedirectToAction("Index", "Home", new { ForgetModal = "true"});

            }
            else
            {
                TempData["Add"] = "alert show alert-danger";
                TempData["message"] = "mail is not found!";
                return RedirectToAction("Index", "Home", new { ForgetModal = "true" });
            }
            

        }

        [HttpGet]
        public IActionResult ResetPassword(int userid)
        {
            TempData["id"] = userid;
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(resetPass user)
        {
            var User = new User() { UserId = user.userid, Password = user.newPassword ,ModifiedDate=DateTime.Now};
            _db.Users.Attach(User);
            _db.Entry(User).Property(x => x.Password).IsModified = true;
            _db.Entry(User).Property(x => x.ModifiedDate).IsModified = true;
            _db.SaveChanges();


            return PartialView();
        }
        

    }
}
