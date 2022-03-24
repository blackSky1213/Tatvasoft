using HelperLand.Data;
using HelperLand.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
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
            if(Id==null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
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

        [HttpGet]
        public JsonResult GetDataForCalendar()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                
                List<ServiceProviderService> request = new List<ServiceProviderService>();
                var table = _db.ServiceRequests.Where(x => x.UserId == Id &&(x.Status!=1)).ToList();
                foreach (var data in table)
                {
                    ServiceProviderService sps = new ServiceProviderService();

                    sps.ServiceRequestId = data.ServiceRequestId;
                    sps.ServiceStartDate = data.ServiceStartDate.ToString("dd/MM/yyyy");
                    sps.Status = data.Status;
                    sps.startTime = data.ServiceStartDate.ToString("HH:mm");

                    sps.endTime = data.ServiceStartDate.AddHours((double)data.SubTotal).ToString("HH:mm");

                    request.Add(sps);

                }
                return new JsonResult(request);
            }

            return new JsonResult("false");
        }


        public IActionResult BookService()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
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
            /*Thread.Sleep(1500);*/
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                var zipcode = _db.Users.Where(x => x.UserTypeId == 2 && x.ZipCode == setupservice.postalCode).ToList();
                if (zipcode.Count()>0)
                {
                    bool isnull = true;
                   foreach(var obj in zipcode)
                    {
                        FavoriteAndBlocked fab = _db.FavoriteAndBlockeds.FirstOrDefault(x => x.UserId == Id && x.TargetUserId == obj.UserId && x.IsBlocked == true);
                        if (fab == null)
                        {
                            isnull =false;
                        }
                    }
                    if (!isnull)
                    {
                        CookieOptions cookie = new CookieOptions();
                        Response.Cookies.Append("zipcode", setupservice.postalCode, cookie);

                        return Ok(Json("true"));
                    }
                    else
                    {
                        return Ok(Json("isBlockByU"));
                    }
                   
                }
               
            }
            
                return Ok(Json("false"));
            
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
                addr.State = address.State;
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
                if(data.ServiceProviderId != null)
                {
                    var thistimeStart = DateTime.Parse(data.startDate.ToString("M/d/yyyy") + " " + data.startTime);
                    var thistimeEnd = thistimeStart.AddHours((double)addService.SubTotal + 1);
                    ServiceRequest conflictService = _db.ServiceRequests.FirstOrDefault(
                        x => x.Status == 2 && (x.ServiceProviderId == data.ServiceProviderId && x.ServiceStartDate <= thistimeStart && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) >= thistimeStart) || (x.ServiceProviderId == data.ServiceProviderId && x.ServiceStartDate <= thistimeEnd && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) >= thistimeEnd) || (x.ServiceProviderId == data.ServiceProviderId && x.ServiceStartDate >= thistimeStart && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) <= thistimeEnd)
                        );

                    if (conflictService != null)
                    {
                        return Ok(Json("conflict"));
                    }

                    addService.ServiceProviderId = data.ServiceProviderId;
                }
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


                List<User> ServiceProviderList = new List<User>();
                string url = Url.ActionLink("ServiceProviderPage", "ServiceProvider");
                string message = "<p>New service coming. get up fast and take it. service id :- "+ ServiceRequest.Entity.ServiceRequestId +
                ". <a href='" + url + "'>Check it on New Service</a></p>";
                if (data.ServiceProviderId == null)
                {
                    ServiceProviderList = (from x in _db.Users  join y in _db.FavoriteAndBlockeds on x.UserId equals y.TargetUserId into pp from y in pp.DefaultIfEmpty()  where (x.UserTypeId==2 && x.ZipCode== address.PostalCode && y.TargetUserId == x.UserId && y.IsBlocked == false) ||(x.UserTypeId==2 && x.ZipCode == address.PostalCode && y==null) select x).ToList();
                   
                   
                }
                else
                {
                   
                    ServiceProviderList = _db.Users.Where(x => x.UserTypeId == 2 && x.UserId==data.ServiceProviderId).ToList();

                    message = "<p>it's seem your hard work done well. you direct assign work by customer, go and check the dtails of service request id :- "+ ServiceRequest.Entity.ServiceRequestId +
                ". <a href='" + url + "'>Check Details of service</a></p>";
                }
               
                
                Task task = Task.Run(() => SendMain(ServiceProviderList,message,"new service request"));
            

                return Ok(Json(ServiceRequest.Entity.ServiceRequestId));
            }

            return Ok(Json("false"));
        }



        private static void SendMain(List<User> ServiceProviderList,string message,string subject)
        {
            SmtpClient setup = new SmtpClient("smtp.gmail.com");
            setup.Port = 587;
            setup.UseDefaultCredentials = true;
            setup.EnableSsl = true;
            setup.Credentials = new System.Net.NetworkCredential("kripcsarvaiya@gmail.com", "9825106734");
          
            string body = message;
            MailMessage mm = new MailMessage();
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("kripcsarvaiya@gmail.com");
            mm.IsBodyHtml = true;
            foreach (var obj in ServiceProviderList)
            {
                string to = obj.Email;

                mm.To.Add(to);
               

               

            }
            setup.Send(mm);
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
                if (request.ServiceProviderId != null)
                {
                    string comments = "";
                    if (data.Comments != null)
                    {
                        comments = data.Comments;
                    }
                  
                    var ServiceProviderList = _db.Users.Where(x => x.UserId == request.ServiceProviderId).ToList();
                    string url = Url.ActionLink("ServiceProviderPage", "ServiceProvider");
                    string message = "<p>Service Request " + request.ServiceRequestId + " has been cancel by customer</p><p><a href='" + url + "'>check it now </a></p><p>reason for cancel :- "+comments+"</p>";

                    Task task = Task.Run(() => SendMain(ServiceProviderList, message, "cancel service"));

                }


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

                if (request.ServiceProviderId != null)
                {
                    var thistimeStart = DateTime.Parse(data.ServiceStartDate + " " + data.startTime);
                    var thistimeEnd = thistimeStart.AddHours((double)request.SubTotal + 1);
                    ServiceRequest conflictService = _db.ServiceRequests.FirstOrDefault(
                        x => x.Status == 2 && (x.ServiceProviderId == request.ServiceProviderId && x.ServiceStartDate <= thistimeStart && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) >= thistimeStart) || (x.ServiceProviderId == request.ServiceProviderId && x.ServiceStartDate <= thistimeEnd && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) >= thistimeEnd) || (x.ServiceProviderId == request.ServiceProviderId && x.ServiceStartDate >= thistimeStart && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) <= thistimeEnd)
                        );

                    if (conflictService != null)
                    {
                        return Ok(Json("conflict"));
                    }
                }
               
                request.ServiceStartDate = DateTime.Parse(data.ServiceStartDate + " " + data.startTime);
                _db.ServiceRequests.Update(request);
                _db.SaveChanges();

                if (request.ServiceProviderId != null)
                {
                    var ServiceProviderList = _db.Users.Where(x => x.UserId == request.ServiceProviderId).ToList();
                    string url = Url.ActionLink("ServiceProviderPage", "ServiceProvider");
                    string message = "<p>Service Request " + request.ServiceRequestId + " has been rescheduled by customer. New date and time are " + request.ServiceStartDate + "</p><p><a href='" + url + "'>check it now </a></p>";

                    Task task = Task.Run(() => SendMain(ServiceProviderList, message, "reschedule service"));


                }
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
                Details.HasPets = request.HasPets;
               
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

                    int CleaningCount = _db.ServiceRequests.Where(x => x.ServiceProviderId == request.ServiceProviderId && x.Status == 0).Count();
                    Details.ServiceProviderCleaning = CleaningCount;
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

        [HttpGet]
        public JsonResult GetCompleteServiceUserList()
        {
            int? Id = HttpContext.Session.GetInt32("id");

            if (Id != null)
            {
                List<int?> request = _db.ServiceRequests.Where(x => x.UserId == Id && x.Status == 0).Select(x => x.ServiceProviderId).Distinct().ToList();
                if (request.Count() > 0)
                {

                    List<BlockFavouriteUser> userblock = new List<BlockFavouriteUser>();
                    foreach (var obj in request)
                    {
                        int CleaningCount = _db.ServiceRequests.Where(x => x.ServiceProviderId == obj && x.Status == 0).Count();


                        FavoriteAndBlocked isCustomerBlock = _db.FavoriteAndBlockeds.FirstOrDefault(x => x.TargetUserId == Id && x.UserId==obj&& x.IsBlocked == true);

                        if (isCustomerBlock==null)
                        {
                            User u = _db.Users.FirstOrDefault(x => x.UserId == obj);
                            BlockFavouriteUser bfu = new BlockFavouriteUser();
                            bfu.ServiceProviderCleaning = CleaningCount;
                            bfu.UserIdFrom = (int)Id;
                            bfu.UserIdTo = (int)obj;
                            bfu.CustomerName = u.FirstName + " " + u.LastName;
                            FavoriteAndBlocked fab = _db.FavoriteAndBlockeds.FirstOrDefault(x => x.UserId == (int)Id && x.TargetUserId == u.UserId);
                            var rating = _db.Ratings.Where(x => x.RatingTo == obj);

                            if (rating.Count() > 0)
                            {

                                bfu.SPRatings = rating.Average(x => x.Ratings);
                            }
                            if (fab != null)
                            {
                                bfu.IsBlock = fab.IsBlocked;
                                bfu.IsFavourite = fab.IsFavorite;
                            }
                            else
                            {
                                bfu.IsBlock = false;
                                bfu.IsFavourite = false;
                            }

                            userblock.Add(bfu);

                        }
                        }
                        return new JsonResult(userblock);
                    
                }
            }
            return new JsonResult("false");
        }

        [HttpPost]
        public IActionResult BlockProvider(BlockFavouriteUser data)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                FavoriteAndBlocked fab = _db.FavoriteAndBlockeds.FirstOrDefault(x => x.UserId == (int)Id && x.TargetUserId == data.UserIdTo);
                if (fab != null)
                {
                    if (fab.IsBlocked == false)
                    {
                        fab.IsBlocked = true;
                    }
                    else
                    {
                        fab.IsBlocked = false;
                    }

                    _db.FavoriteAndBlockeds.Update(fab);
                    _db.SaveChanges();

                }
                else
                {
                    FavoriteAndBlocked Newfab = new FavoriteAndBlocked();
                    Newfab.UserId = (int)Id;
                    Newfab.TargetUserId = data.UserIdTo;
                    Newfab.IsBlocked = true;
                    _db.FavoriteAndBlockeds.Add(Newfab);
                    _db.SaveChanges();
                }


                return Ok(Json("true"));
            }
            return Ok(Json("false"));
        }


        [HttpPost]
        public IActionResult FavouriteProvider(BlockFavouriteUser data)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                FavoriteAndBlocked fab = _db.FavoriteAndBlockeds.FirstOrDefault(x => x.UserId == (int)Id && x.TargetUserId == data.UserIdTo);
                if (fab != null)
                {
                    if (fab.IsFavorite == false)
                    {
                        fab.IsFavorite = true;
                    }
                    else
                    {
                        fab.IsFavorite = false;
                    }

                    _db.FavoriteAndBlockeds.Update(fab);
                    _db.SaveChanges();

                }
                else
                {
                    FavoriteAndBlocked Newfab = new FavoriteAndBlocked();
                    Newfab.UserId = (int)Id;
                    Newfab.TargetUserId = data.UserIdTo;
                    Newfab.IsFavorite = true;
                    _db.FavoriteAndBlockeds.Add(Newfab);
                    _db.SaveChanges();
                }


                return Ok(Json("true"));
            }
            return Ok(Json("false"));
        }

        [HttpGet]
        public JsonResult GetFavProvider(User zip)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                var FavPro = _db.FavoriteAndBlockeds.Where(x => x.UserId == Id && x.IsFavorite == true).ToList();
               
                if (FavPro.Count() > 0) {
                    List<BlockFavouriteUser> bfu = new List<BlockFavouriteUser>();
                    foreach(var obj in FavPro)
                    {
                        var isInYourArea = _db.Users.FirstOrDefault(x =>  x.UserId == obj.TargetUserId &&x.UserTypeId==2 && x.ZipCode == zip.ZipCode);
                        if (isInYourArea != null)
                        {
                            var isCustomerBlock = _db.FavoriteAndBlockeds.FirstOrDefault(x => x.UserId == isInYourArea.UserId && x.TargetUserId == Id && x.IsBlocked == true);
                            if (isCustomerBlock == null)
                            {
                                BlockFavouriteUser data = new BlockFavouriteUser();

                                data.UserIdFrom = (int)Id;
                                data.UserIdTo = isInYourArea.UserId;


                                data.ServiceProviderName = isInYourArea.FirstName + " " + isInYourArea.LastName;

                                bfu.Add(data);

                                
                            }

                        }

                    }

                    return new JsonResult(bfu);

                }

               
            }

            return new JsonResult("false");
        }


    }

    }

