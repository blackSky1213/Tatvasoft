﻿using HelperLand.Data;
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
            var Id = HttpContext.Session.GetInt32("id");
            if (Id!=null)
            {
                var obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                if (obj.UserTypeId == 1)
                {
                    ViewBag.Name = obj.FirstName;
                    return PartialView();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else if(Request.Cookies["userid"]!=null){
                var obj = _db.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userid"]));
                if (obj.UserTypeId == 1)
                {
                    ViewBag.Name = obj.FirstName;
                    return PartialView();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            {
                return RedirectToAction("Index", "Home", new { loginModel = "true" });
            }
         
        }
    }
}