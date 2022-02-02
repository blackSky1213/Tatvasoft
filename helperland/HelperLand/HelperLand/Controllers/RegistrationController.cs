using HelperLand.Data;
using HelperLand.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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



    }
}
