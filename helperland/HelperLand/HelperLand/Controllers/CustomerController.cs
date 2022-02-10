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
                return RedirectToAction("Index", "Home", new { loginModal = "true" });
            }
         
        }


        public IActionResult BookService()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
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
            else if (Request.Cookies["userid"] != null)
            {
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
            else
            {
                return RedirectToAction("Index", "Home", new { loginModal = "true" });
            }


            
        }

        [HttpPost]
        public ActionResult IsValidZipcode(setupService setupservice)
        {
            var zipcodes = _db.Zipcodes.Where(x => x.ZipcodeValue == setupservice.postalCode);
            if (zipcodes.Count() > 0)
            {
                CookieOptions cookie = new CookieOptions();
                Response.Cookies.Append("zipcode", setupservice.postalCode, cookie);
                return Ok(Json("true"));
            }
            else
            {
                return Ok(Json("false"));
            }
        }

        [HttpPost]
        public ActionResult getScheduleServiceDetails(scheduleService data)
        {
            
            if (ModelState.IsValid)
            {
                return Ok(Json("true"));
            }
            else
            {
                return Ok(Json("false"));
            }

        }


        [HttpGet]
        public JsonResult getAddressDetails()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            List<AddressDetails> addresses = new List<AddressDetails>();
            var zipCode = Request.Cookies["zipcode"];
            var userAddress = _db.UserAddresses.Where(x => x.PostalCode == zipCode && x.UserId == Id).ToList();

            foreach(var address in userAddress)
            {
                AddressDetails addr = new AddressDetails();
                addr.AddressLine1 = address.AddressLine1;
                addr.AddressLine2 = address.AddressLine2;
                addr.City = address.City;
                addr.Mobile = address.Mobile;
                addr.PostalCode = address.PostalCode;

                addresses.Add(addr);
            }

            return new JsonResult(addresses);
            
        }


    }
}
