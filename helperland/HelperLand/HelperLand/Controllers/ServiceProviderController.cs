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
    public class ServiceProviderController : Controller
    {
        private readonly HelperlandContext _db;
        public ServiceProviderController(HelperlandContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult ServiceProviderPage()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                if (obj.UserTypeId == 2)
                {
                    ViewBag.Name = obj;
                    UserAddress user = _db.UserAddresses.FirstOrDefault(x => x.UserId == Id);
                    List<ServiceProviderService> request = new List<ServiceProviderService>();
                    var table = _db.ServiceRequests.Where(x => x.ServiceProviderId == null && x.ZipCode == user.PostalCode && x.Status == 2).ToList();
                    foreach(var data in table)
                    {
                        ServiceProviderService sps = new ServiceProviderService();
                        sps.ServiceRequestId = data.ServiceRequestId;
                        sps.ServiceStartDate = data.ServiceStartDate.ToString("dd/MM/yyyy");

                        sps.startTime = data.ServiceStartDate.ToString("HH:mm");
                        var thistimeStart = data.ServiceStartDate;
                        var thistimeEnd = data.ServiceStartDate.AddHours((double)data.SubTotal+1);
                        ServiceRequest conflictService = _db.ServiceRequests.FirstOrDefault(
                            x=>(x.ServiceProviderId==(int)Id && x.ServiceStartDate <= thistimeStart && x.ServiceStartDate.AddHours((double)x.SubTotal+1)>=thistimeStart) || (x.ServiceProviderId == (int)Id && x.ServiceStartDate <= thistimeEnd && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) >= thistimeEnd) || (x.ServiceProviderId == (int)Id && x.ServiceStartDate >= thistimeStart && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) <= thistimeEnd)
                            );
                        if (conflictService!=null)
                        {
                            sps.timeConflict = conflictService.ServiceRequestId;
                        }
                        sps.endTime = data.ServiceStartDate.AddHours((double)data.SubTotal).ToString("HH:mm");
                        sps.TotalCost = data.TotalCost;
                        ServiceRequestAddress requestaddr = _db.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);
                        sps.CustomerAddress1 = requestaddr.AddressLine2 + " " + requestaddr.AddressLine1;
                        sps.CustomerAddress2 = data.ZipCode + " " + requestaddr.City;
                        User u = _db.Users.FirstOrDefault(x => x.UserId == data.UserId);
                        sps.CustomerName = u.FirstName + " " + u.LastName;
                        request.Add(sps);

                    }
                    return PartialView(request);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else if (Request.Cookies["userid"] != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userid"]));
                if (obj.UserTypeId == 2)
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
        public JsonResult getUserDetails()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }

            if (Id != null)
            {
                User user = _db.Users.FirstOrDefault(x => x.UserId == Id);
               User sp=new User();
                if (user != null)
                {
                    sp = user;
                }
                
                UserAddress userAddress = _db.UserAddresses.FirstOrDefault(x => x.UserId == Id);
                if (userAddress != null)
                {
                    sp.UserAddresses.Add(userAddress);
                }

                return new JsonResult(sp);


            }
            return new JsonResult("false");

        }


        [HttpPost]
        public IActionResult updateUserDetails(User data)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
            if (Id != null)
            {
                User u = _db.Users.FirstOrDefault(x => x.UserId == Id);
                u.FirstName = data.FirstName;
                u.LastName = data.LastName;
                u.Mobile = data.Mobile;
                u.DateOfBirth = data.DateOfBirth;
                u.Gender = data.Gender;
                u.UserProfilePicture = data.UserProfilePicture;
                u.ModifiedDate = DateTime.Now;
                u.ModifiedBy = u.UserId;
                

                if (u.UserAddresses.Count() > 0)
                {
                    
                    data.UserAddresses.Last().IsDefault = u.UserAddresses.Last().IsDefault;
                    data.UserAddresses.Last().IsDeleted = u.UserAddresses.Last().IsDeleted;
                    data.UserAddresses.Last().UserId = u.UserId;
                    data.UserAddresses.Last().Mobile = u.Mobile;
                    data.UserAddresses.Last().Email = u.Email;



                    _db.UserAddresses.Update(data.UserAddresses.Last());

                }
                else
                {
                    data.UserAddresses.Last().IsDefault = true;
                    data.UserAddresses.Last().IsDeleted = false;
                    data.UserAddresses.Last().UserId = u.UserId;


                    _db.UserAddresses.Add(data.UserAddresses.Last());

                }
                
               
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


        [HttpPost]
        public IActionResult UpdateUserPassword(AuthLogin changePass)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User u = _db.Users.FirstOrDefault(x => x.UserId == Id);
                bool IsPassValid = BCrypt.Net.BCrypt.Verify(changePass.password, u.Password);
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

        public IActionResult AcceptServiceRequest(ServiceRequest data)
        {

            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                ServiceRequest request = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);
                request.ServiceProviderId = (int)Id;
                _db.ServiceRequests.Update(request);
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
                CustomerServiceRequestSummery Details = new CustomerServiceRequestSummery();
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
               
                    User customerName = _db.Users.Where(x => x.UserId == request.UserId).FirstOrDefault();

                    Details.ServiceProviderName = customerName.FirstName + " " + customerName.LastName;

                    


             


                return new JsonResult(Details);
            }

            return new JsonResult("false");

        }



        [HttpGet]
        public JsonResult GetUpcomingService()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);
                
                    
                    UserAddress user = _db.UserAddresses.FirstOrDefault(x => x.UserId == Id);
                    List<ServiceProviderService> request = new List<ServiceProviderService>();
                    var table = _db.ServiceRequests.Where(x => x.ServiceProviderId == Id && x.Status == 2).ToList();
                    foreach (var data in table)
                    {
                        ServiceProviderService sps = new ServiceProviderService();
                        sps.ServiceRequestId = data.ServiceRequestId;
                        sps.ServiceStartDate = data.ServiceStartDate.ToString("dd/MM/yyyy");

                        sps.startTime = data.ServiceStartDate.ToString("HH:mm");
                        
                        sps.endTime = data.ServiceStartDate.AddHours((double)data.SubTotal).ToString("HH:mm");
                        sps.TotalCost = data.TotalCost;
                        ServiceRequestAddress requestaddr = _db.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);
                        sps.CustomerAddress1 = requestaddr.AddressLine2 + " " + requestaddr.AddressLine1;
                        sps.CustomerAddress2 = data.ZipCode + " " + requestaddr.City;
                        User u = _db.Users.FirstOrDefault(x => x.UserId == data.UserId);
                        sps.CustomerName = u.FirstName + " " + u.LastName;
                        request.Add(sps);

                    }
                    return new JsonResult(request);
                }

            return new JsonResult("false");
            
        }


        public IActionResult RejectService(ServiceRequest data)
        {

            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                ServiceRequest request = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);

                request.ServiceProviderId = null;

                _db.ServiceRequests.Update(request);
                _db.SaveChanges();

                return Ok(Json("true"));

            }

            return Ok(Json("fasle"));
        }



        [HttpGet]
        public JsonResult GetServiceHistory()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                User obj = _db.Users.FirstOrDefault(x => x.UserId == Id);


                UserAddress user = _db.UserAddresses.FirstOrDefault(x => x.UserId == Id);
                List<ServiceProviderService> request = new List<ServiceProviderService>();
                var table = _db.ServiceRequests.Where(x => x.ServiceProviderId == Id && x.Status == 0).ToList();
                foreach (var data in table)
                {
                    ServiceProviderService sps = new ServiceProviderService();
                    sps.ServiceRequestId = data.ServiceRequestId;
                    sps.ServiceStartDate = data.ServiceStartDate.ToString("dd/MM/yyyy");

                    sps.startTime = data.ServiceStartDate.ToString("HH:mm");

                    sps.endTime = data.ServiceStartDate.AddHours((double)data.SubTotal).ToString("HH:mm");
                    sps.TotalCost = data.TotalCost;
                    ServiceRequestAddress requestaddr = _db.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);
                    sps.CustomerAddress1 = requestaddr.AddressLine2 + " " + requestaddr.AddressLine1;
                    sps.CustomerAddress2 = data.ZipCode + " " + requestaddr.City;
                    User u = _db.Users.FirstOrDefault(x => x.UserId == data.UserId);
                    sps.CustomerName = u.FirstName + " " + u.LastName;
                    request.Add(sps);

                }
                return new JsonResult(request);
            }

            return new JsonResult("false");

        }

        public JsonResult GetRatingOfServiceProvider()
        {
            int? Id = HttpContext.Session.GetInt32("id");

            if (Id != null)
            {
                
                var table = _db.Ratings.Where(x => x.RatingTo == Id).ToList();
                if (table != null)
                {
                    List<ServiceProviderService> ratingDetails = new List<ServiceProviderService>();
                    foreach (var obj in table)
                    {
                        ServiceProviderService sps = new ServiceProviderService();

                        sps.ServiceRequestId = obj.ServiceRequestId;
                        ServiceRequest data = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == obj.ServiceRequestId);
                        sps.ServiceStartDate = data.ServiceStartDate.ToString("dd/MM/yyyy");
                        sps.startTime = data.ServiceStartDate.ToString("HH:mm");
                        sps.endTime = data.ServiceStartDate.AddHours((double)data.SubTotal).ToString("HH:mm");
                        sps.Comments = obj.Comments;
                        User name = _db.Users.FirstOrDefault(x => x.UserId == obj.RatingFrom);
                        sps.CustomerName = name.FirstName + " " + name.LastName;
                        sps.SPRatings = obj.Ratings;

                        ratingDetails.Add(sps);

                       
                    }
                    return new JsonResult(ratingDetails);
                }
                
               
            }
            return new JsonResult("false");
        }

    }
}
