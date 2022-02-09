using HelperLand.Data;
using HelperLand.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

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
                    string HashPass = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Password = HashPass;
                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.IsRegisteredUser = true;
                    user.ModifiedBy = 123;
                    user.ForgetPass = "false";
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
                    string HashPass = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Password = HashPass;
                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.IsRegisteredUser = true;
                    user.ModifiedBy = 123;
                    user.ForgetPass = "false";
                      
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
            if(ModelState.IsValid)
            {
                
                if (_db.Users.Where(x => x.Email == user.username).Count() > 0)
                {


                    User U = _db.Users.FirstOrDefault(x => x.Email == user.username);
                    bool IsPassValid = BCrypt.Net.BCrypt.Verify(user.password, U.Password);
                    if (IsPassValid)
                    {
                        if (user.remember == true)
                        {
                            CookieOptions MyCookie = new CookieOptions();
                            MyCookie.Expires = DateTime.Now.AddSeconds(30);
                            Response.Cookies.Append("userid", Convert.ToString(U.UserId),MyCookie);
                            

                        }


                        HttpContext.Session.SetInt32("id", U.UserId);


                        if (U.UserTypeId == 1)
                        {
                            
                            
                            return RedirectToAction("CustomerServiceHistory", "Customer");
                        }
                        else if (U.UserTypeId == 2)
                        {
                            return RedirectToAction("UpcomingService", "ServiceProvider");

                        }
                        else if (U.UserTypeId == 3)
                        {
                            return RedirectToAction("UserDetailsTable", "Admin");
                        }
                    }
                    else
                    {
                        TempData["add"] = "alert show";
                        TempData["fail"] = "username and password are invalid";
                        return RedirectToAction("Index", "Home", new { loginModal = "true" });

                    }


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
        
     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgetPass(ForgetPass user)
        {
            if(_db.Users.Where(x=> x.Email == user.email).Count() > 0)
            {
                User Id = _db.Users.FirstOrDefault(x => x.Email == user.email);
                Id.ForgetPass = "true";
                _db.Users.Update(Id);
                _db.SaveChanges();
                string to = user.email;
                string token = BCrypt.Net.BCrypt.HashPassword(user.email);
                string subject = "Reset password";
                string body = "<p>Reset your password by click below link " +
                    "<a href='" + Url.Action("ResetPassword", "Registration",new { userid=Id.UserId,token=token}, "https") + "'>Reset Password</a></p>"; 
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
                setup.Credentials = new System.Net.NetworkCredential("kripcsarvaiya@gmail.com", "9825106734");
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
        public IActionResult ResetPassword(int userid,string token)
        {
            TempData["id"] = userid;
            User user = _db.Users.FirstOrDefault(x => x.UserId == userid);
            bool isValidId = BCrypt.Net.BCrypt.Verify(user.Email, token);
            
            if (isValidId && user.ForgetPass=="true")
            {
                
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(resetPass user)      
        {
            if (ModelState.IsValid)
            {
                User u = _db.Users.FirstOrDefault(x => x.UserId == user.userid);
                string HashPass = BCrypt.Net.BCrypt.HashPassword(user.newPassword);
                u.Password = HashPass;
                u.ModifiedDate = DateTime.Now;
                u.ForgetPass = "false";
                _db.Users.Update(u);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return PartialView();
            }

            
        }
        
       
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("userid");
            
            return RedirectToAction("Index", "Home", new { LogoutModal = "true" });
        }


       

    }
}
