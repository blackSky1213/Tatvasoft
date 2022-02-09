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
    public class CustomerController : Controller
    {
        private readonly HelperlandContext _db;
       

       
        public CustomerController(HelperlandContext db)
        {
            _db = db;
           
        }

        public IActionResult CustomerServiceHistory()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id!=null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                if (obj.UserTypeId == 1)
                {
                    ViewBag.Name = obj;
                    return PartialView();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else if(Request.Cookies["userid"]!=null){
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userid"]));
                if (obj.UserTypeId == 1)
                {
                    ViewBag.Name = obj;
                    return PartialView();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
           else {
                return RedirectToAction("Index", "Home", new { loginModel = "true" });
            }
         
        }

        public IActionResult BookService()
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
              
            }
            return PartialView();
        }


        [HttpPost]
        public IActionResult ValidZipcode(setupService setupservice)
        {
            var zipcode = _db.Zipcodes.Where(x => x.ZipcodeValue == setupservice.postalCode);
            if (zipcode.Count() > 0)
            {
                return RedirectToAction("BookService", "Customer", new { scheduleService = "true" });
            }
            else
            {
                return RedirectToAction("BookService", "Customer");
            }

        }
       
        [HttpPost]
        public IActionResult ScheduleService(scheduleService schedule)
        {
           
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
               
            }
            else
            {
                if (_db.Users.Where(x => x.Email == schedule.username).Count() > 0)
                {


                    User U = _db.Users.FirstOrDefault(x => x.Email == schedule.username);
                    bool IsPassValid = BCrypt.Net.BCrypt.Verify(schedule.password, U.Password);
                    if (IsPassValid)
                    {
                        if (schedule.rememberMe == true)
                        {
                            CookieOptions MyCookie = new CookieOptions();
                            MyCookie.Expires = DateTime.Now.AddSeconds(30);
                            Response.Cookies.Append("userid", Convert.ToString(U.UserId), MyCookie);


                        }


                        HttpContext.Session.SetInt32("id", U.UserId);


                        if (U.UserTypeId == 1)
                        {


                            return RedirectToAction("BookService", "Customer",
                                new {address="true" });
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

        
            return RedirectToAction("BookService", "Customer", new { scheduleService = "true" });
        }
    }
}
