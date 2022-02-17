using HelperLand.Data;
using HelperLand.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            Thread.Sleep(1500);
            var zipcodes = _db.Zipcodes.Where(x => x.ZipcodeValue == setupservice.postalCode);
            if (zipcodes.Count() > 0)
            {
                var cityId = zipcodes.FirstOrDefault().CityId;
                string city = _db.Cities.FirstOrDefault(x => x.Id == cityId).CityName;
                CookieOptions cookie = new CookieOptions();
                Response.Cookies.Append("zipcode", setupservice.postalCode, cookie);
                Response.Cookies.Append("city",city,cookie);
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
                addr.Id = address.AddressId;
                addr.AddressLine1 = address.AddressLine1;
                addr.AddressLine2 = address.AddressLine2;
                addr.City = address.City;
                addr.Mobile = address.Mobile;
                addr.PostalCode = address.PostalCode;
                addr.IsDefault = address.IsDefault;

                addresses.Add(addr);
            }

            return new JsonResult(addresses);
            
        }


        [HttpPost]
        public IActionResult addAddress(UserAddress address)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User user = _db.Users.FirstOrDefault(x => x.UserId == Id);
                address.Email = user.Email;
                address.UserId = user.UserId;
                address.IsDefault = false;
                address.IsDeleted = false;
                _db.UserAddresses.Add(address);
                _db.SaveChanges();

                return Ok(Json("true"));


            }
            return Ok(Json("false"));

        }


        [HttpPost]
        public IActionResult PayDone(ServiceDetailsAdd data)
        {
            
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                ServiceRequest addService=new ServiceRequest();
                addService.UserId =(int)Id;
                addService.ServiceId = (int)Id;
                addService.ServiceStartDate = data.startDate;
                addService.ZipCode = data.postalCode;
                addService.ServiceHourlyRate = 20;
                addService.ServiceHours = data.duration;
                addService.ExtraHours = data.extraHours;
                addService.SubTotal = (decimal)data.extraHours + (decimal)data.duration;
                addService.TotalCost = (decimal)(addService.SubTotal *addService.ServiceHourlyRate);
                addService.Comments = data.comment;
                addService.HasPets = data.havePet;
                addService.PaymentDue = false;
                addService.PaymentDone = true;
                addService.HasIssue = false;
                addService.CreatedDate =  DateTime.Now;
                addService.ModifiedDate = DateTime.Now;
                addService.ModifiedBy = Id;

                var ServiceRequest=_db.ServiceRequests.Add(addService);
                _db.SaveChanges();

                UserAddress address = _db.UserAddresses.FirstOrDefault(x => x.AddressId == data.AddressId);

                ServiceRequestAddress serviceAddress = new ServiceRequestAddress();
                serviceAddress.AddressLine1 = address.AddressLine1;
                serviceAddress.AddressLine2 = address.AddressLine2;
                serviceAddress.City = address.City;
                serviceAddress.ServiceRequestId = ServiceRequest.Entity.ServiceRequestId;
                serviceAddress.PostalCode = address.PostalCode;
                serviceAddress.Mobile = address.Mobile;
                serviceAddress.State = address.State;

                var addServiceAddress = _db.ServiceRequestAddresses.Add(serviceAddress);
                _db.SaveChanges();



                

                if (data.cabinet)
                {
                    ServiceRequestExtra addServiceExtra = new ServiceRequestExtra();
                    addServiceExtra.ServiceRequestId = ServiceRequest.Entity.ServiceRequestId;
                    addServiceExtra.ServiceExtraId = 1;
                    _db.ServiceRequestExtras.Add(addServiceExtra);
                    _db.SaveChanges();
                }

                
                if (data.fridge)
                {
                    ServiceRequestExtra addServiceExtra = new ServiceRequestExtra();
                    addServiceExtra.ServiceRequestId = ServiceRequest.Entity.ServiceRequestId;
                    addServiceExtra.ServiceExtraId = 2;
                    _db.ServiceRequestExtras.Add(addServiceExtra);
                    _db.SaveChanges();
                }
                if (data.oven)
                {
                    ServiceRequestExtra addServiceExtra = new ServiceRequestExtra();
                    addServiceExtra.ServiceRequestId = ServiceRequest.Entity.ServiceRequestId;
                    addServiceExtra.ServiceExtraId = 3;
                    _db.ServiceRequestExtras.Add(addServiceExtra);
                    _db.SaveChanges();
                }
                if (data.lundary)
                {
                    ServiceRequestExtra addServiceExtra = new ServiceRequestExtra();
                    addServiceExtra.ServiceRequestId = ServiceRequest.Entity.ServiceRequestId;
                    addServiceExtra.ServiceExtraId = 4;
                    _db.ServiceRequestExtras.Add(addServiceExtra);
                    _db.SaveChanges();
                }
                if (data.windows)
                {
                    ServiceRequestExtra addServiceExtra = new ServiceRequestExtra();
                    addServiceExtra.ServiceRequestId = ServiceRequest.Entity.ServiceRequestId;
                    addServiceExtra.ServiceExtraId = 5;
                    _db.ServiceRequestExtras.Add(addServiceExtra);
                    _db.SaveChanges();
                }

                return Ok(Json(ServiceRequest.Entity.ServiceRequestId));
            }

            return Ok(Json("false"));
        }
        

    


    }
}
