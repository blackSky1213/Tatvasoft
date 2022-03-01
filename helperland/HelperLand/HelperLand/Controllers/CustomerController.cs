using HelperLand.Data;
using HelperLand.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (Id != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                if (obj.UserTypeId == 1)
                {
                    ViewBag.Name = obj;

                    List<CustomerNewServiceRequest> dashboard = new List<CustomerNewServiceRequest>();

                    var table = _db.ServiceRequests.Where(x => x.UserId == Id && x.Status == 2).ToList();

                    foreach (var data in table)
                    {

                        CustomerNewServiceRequest sr = new CustomerNewServiceRequest();
                        sr.ServiceRequestId = data.ServiceRequestId;
                        sr.ServiceStartDate = data.ServiceStartDate.ToString("dd/MM/yyyy");
                        sr.startTime = data.ServiceStartDate.ToString("HH:mm");
                        sr.endTime = data.ServiceStartDate.AddHours((double)data.SubTotal).ToString("HH:mm");
                        sr.TotalCost = data.TotalCost;


                        if (data.ServiceProviderId != null)
                        {
                            User sp = _db.Users.Where(x => x.UserId == data.ServiceProviderId).FirstOrDefault();

                            sr.ServiceProvider = sp.FirstName + " " + sp.LastName;



                            var rating = _db.Ratings.Where(x => x.RatingTo == data.ServiceProviderId);

                            if (rating.Count()>0)
                            {

                                sr.SPRatings = Math.Round(rating.Average(x => x.Ratings), 1);
                            }



                        }

                        dashboard.Add(sr);
                    }
                    return PartialView(dashboard);
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
                Response.Cookies.Append("city", city, cookie);
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
            var userAddress = _db.UserAddresses.Where(x => x.PostalCode == zipCode && x.UserId == Id && x.IsDeleted== false).ToList();

            foreach (var address in userAddress)
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
                ServiceRequest addService = new ServiceRequest();
                addService.UserId = (int)Id;
                addService.ServiceId = (int)Id;
                addService.ServiceStartDate = DateTime.Parse(data.startDate.ToString("M/d/yyyy") + " " + data.startTime);
                addService.ZipCode = data.postalCode;
                addService.ServiceHourlyRate = 20;
                addService.ServiceHours = data.duration;
                addService.ExtraHours = data.extraHours;
                addService.SubTotal = (decimal)data.extraHours + (decimal)data.duration;
                addService.TotalCost = (decimal)(addService.SubTotal * addService.ServiceHourlyRate);
                addService.Comments = data.comment;
                addService.HasPets = data.havePet;
                addService.PaymentDue = false;
                addService.PaymentDone = true;
                addService.HasIssue = false;
                addService.CreatedDate = DateTime.Now;
                addService.ModifiedDate = DateTime.Now;
                addService.ModifiedBy = Id;
                addService.Status = 2;

                var ServiceRequest = _db.ServiceRequests.Add(addService);
                _db.SaveChanges();

                UserAddress address = _db.UserAddresses.FirstOrDefault(x => x.AddressId == data.AddressId);
                address.IsDefault = true;
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

        [HttpPost]
        public IActionResult CancelServiceRequest(ServiceRequest data)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                ServiceRequest request = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);
                request.Comments = data.Comments;
                /* status 
                 * 0 = completed
                 * 1 = cancel
                 * 2 = pending
                 * 
                       */
                request.Status = 1;
                _db.ServiceRequests.Update(request);
                _db.SaveChanges();

                return Ok(Json("true"));

            }
            return Ok(Json("false"));


        }

        [HttpPost]
        public IActionResult UpdateServiceRequest(CustomerNewServiceRequest data)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                ServiceRequest request = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);

                request.ServiceStartDate = DateTime.Parse(data.ServiceStartDate + " " + data.startTime);

                _db.ServiceRequests.Update(request);
                _db.SaveChanges();
                return Ok(Json("true"));
            }

            return Ok(Json("false"));
            


        }



        [HttpGet]
        public JsonResult getUserDetails()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User data = _db.Users.FirstOrDefault(x => x.UserId == Id);
                if (data != null)
                {
                    return new JsonResult(data);
                }
            }
            return new JsonResult(null);
        }


        public IActionResult updateUserDetails(User data)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                var u = _db.Users.FirstOrDefault(x => x.UserId==Id);

                u.FirstName = data.FirstName;
                u.LastName = data.LastName;
                u.Mobile = data.Mobile;

                
                u.DateOfBirth = data.DateOfBirth;
                u.ModifiedDate = DateTime.Now;
                if (_db.Users.Where(x => x.Mobile == data.Mobile && x.UserId == Id).Count() == 1 || _db.Users.Where(x => x.Mobile == data.Mobile).Count() == 0)
                {
                    _db.Users.Update(u);
                    _db.SaveChanges();

                    return Ok(Json("true"));
                }
                else
                {
                    return Ok(Json("mobileThere"));
                }

            }

            return Ok(Json("false"));

        }


        [HttpGet]
        public JsonResult getAllAddressDetails()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                List<AddressDetails> addresses = new List<AddressDetails>();

                var userAddress = _db.UserAddresses.Where(x => x.UserId == Id && x.IsDeleted==false).ToList();

                foreach (var address in userAddress)
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
            return new JsonResult(null);

        }


        [HttpPost]
        public IActionResult UpdateUserPassword(AuthLogin changePass)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User u = _db.Users.FirstOrDefault(x => x.UserId == Id);
                bool IsPassValid = BCrypt.Net.BCrypt.Verify(changePass.password,u.Password);
                if (IsPassValid)
                {
                    string HashPass = BCrypt.Net.BCrypt.HashPassword(changePass.NewPassword);
                    u.Password = HashPass;
                    _db.Users.Update(u);
                    _db.SaveChanges();
                    return Ok(Json("true"));
                }
                
            }
            return Ok(Json("false"));
        }

        [HttpPost]
        public IActionResult UserAddAddress(UserAddress address)
        {
            int? Id = HttpContext.Session.GetInt32("id");

            if(Id != null)
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
        public IActionResult UserUpdateAddress(UserAddress address)
        {
            int? Id = HttpContext.Session.GetInt32("id");

            if (Id != null)
            {
                User user = _db.Users.FirstOrDefault(x => x.UserId == Id);
                address.Email = user.Email;
                address.UserId = user.UserId;
                address.IsDefault = false;
                address.IsDeleted = false;
                _db.UserAddresses.Update(address);
                _db.SaveChanges();

                return Ok(Json("true"));
            }
            return Ok(Json("false"));

        }



        [HttpPost]
        public IActionResult deleteUserAddress(UserAddress addrId)
        {
            int? Id = HttpContext.Session.GetInt32("id");

            if (Id != null)
            {
                UserAddress uaddress = _db.UserAddresses.FirstOrDefault(x => x.AddressId == addrId.AddressId);

                uaddress.IsDeleted = true;
                _db.UserAddresses.Update(uaddress);
                _db.SaveChanges();

                return Ok(Json("true"));
            }

            return Ok(Json("false"));
        }

        public JsonResult showServiceRequestSummery(ServiceRequest data)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                ServiceRequest request = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);
                List<ServiceRequestExtra> requestExtra = _db.ServiceRequestExtras.Where(x => x.ServiceRequestId == request.ServiceRequestId).ToList();
                ServiceRequestAddress requestAddress = _db.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == request.ServiceRequestId);
                CustomerServiceRequestSummery Details=new CustomerServiceRequestSummery();
                Details.ServiceRequestId = request.ServiceRequestId;
                Details.Date = request.ServiceStartDate.ToString("dd/MM/yyyy");
                Details.StartTime = request.ServiceStartDate.ToString("HH:mm");
                Details.Duration = request.SubTotal;
                Details.EndTime = request.ServiceStartDate.AddHours((double)request.SubTotal).ToString("HH:mm");
                Details.TotalCost = request.TotalCost;
                Details.Comments = request.Comments;
                foreach (ServiceRequestExtra row in requestExtra)
                {
                    if (row.ServiceExtraId == 1)
                    {
                        Details.Cabinet = true;
                    }
                    else if (row.ServiceExtraId == 2)
                    {
                        Details.Oven = true;
                    }
                    else if (row.ServiceExtraId == 3)
                    {
                        Details.Window = true;
                    }
                    else if (row.ServiceExtraId == 4)
                    {
                        Details.Fridge = true;
                    }
                    else
                    {
                        Details.Laundry = true;
                    }
                }
                Details.Address = requestAddress.AddressLine1 + ", " + requestAddress.AddressLine2 + ", " + requestAddress.City + "- " + requestAddress.PostalCode;
                Details.PhoneNo = requestAddress.Mobile;
                Details.Email = requestAddress.Email;
                if (request.ServiceProviderId != null)
                {
                    User sp = _db.Users.Where(x => x.UserId == request.ServiceProviderId).FirstOrDefault();

                    Details.ServiceProviderName = sp.FirstName + " " + sp.LastName;



                    var rating = _db.Ratings.Where(x => x.RatingTo == request.ServiceProviderId);

                    if (rating.Count()>0)
                    {

                        Details.ServiceProviderRating = Math.Round(rating.Average(x => x.Ratings),1);
                    }



                }


                return new JsonResult(Details);
            }

            return new JsonResult("false");

        }


        public JsonResult getAddressFieldData(UserAddress address)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                UserAddress addr = _db.UserAddresses.FirstOrDefault(x => x.AddressId == address.AddressId);
                return new JsonResult(addr);
            }
            return new JsonResult("false");

        }


        public JsonResult getscheduleDataTime(ServiceRequest request)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                ServiceRequest service = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == request.ServiceRequestId);

                return new JsonResult(service.ServiceStartDate);
            }
            return new JsonResult("false");
        }


        public JsonResult ServiceHistory()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                List<CustomerNewServiceRequest> ServiceHistory = new List<CustomerNewServiceRequest>();

                var table = _db.ServiceRequests.Where(x => x.UserId == Id && x.Status != 2).ToList();

                foreach (var data in table)
                {

                    CustomerNewServiceRequest sr = new CustomerNewServiceRequest();
                    var r = _db.Ratings.Where(x => x.ServiceRequestId == data.ServiceRequestId);
                    if (r.Count() > 0)
                    {
                        sr.AlreadyRated = true;
                    }
                    else
                    {
                        sr.AlreadyRated = false;
                    }
                    sr.ServiceRequestId = data.ServiceRequestId;
                    sr.ServiceStartDate = data.ServiceStartDate.ToString("dd/MM/yyyy");
                    sr.startTime = data.ServiceStartDate.ToString("HH:mm");
                    sr.endTime = data.ServiceStartDate.AddHours((double)data.SubTotal).ToString("HH:mm");
                    sr.TotalCost = data.TotalCost;
                    sr.Status = data.Status;
                    
                    if (data.ServiceProviderId != null)
                    {
                        User sp = _db.Users.Where(x => x.UserId == data.ServiceProviderId).FirstOrDefault();

                        sr.ServiceProvider = sp.FirstName + " " + sp.LastName;



                        var rating = _db.Ratings.Where(x => x.RatingTo == data.ServiceProviderId);
                       
                        if (rating.Count() > 0)
                        {
                          
                            sr.SPRatings = rating.Average(x => x.Ratings);
                        }

                       

                    }

                    ServiceHistory.Add(sr);
                }
                return new JsonResult(ServiceHistory);

            }
            return new JsonResult("false");
        }



        public IActionResult addServiceProviderRating(Rating data)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null )
            {
                if (_db.Ratings.Where(x => x.ServiceRequestId == data.ServiceRequestId).Count() < 0)
                {
                    return Ok(Json("false"));
                }
                ServiceRequest request = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);
                data.RatingTo = (int)request.ServiceProviderId;
                data.RatingFrom = (int)Id;
                data.RatingDate = DateTime.Now;
                _db.Ratings.Add(data);
                _db.SaveChanges();

                return Ok(Json("true"));
            }
            return Ok(Json("false"));

        }


    }

    }
