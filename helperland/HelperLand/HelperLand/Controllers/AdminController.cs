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
    public class AdminController : Controller
    {
        private readonly HelperlandContext _db;

        public AdminController(HelperlandContext db)
        {
            _db = db;
        }
        public IActionResult UserDetailsTable()
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
                if (obj.UserTypeId == 3)
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
                if (obj.UserTypeId == 3)
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


        public IActionResult GetUserList(AdminUserList Admindata)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
            if (Id != null)
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var customerData =(from x in _db.Users select x) ;

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    if (sortColumnDirection == "asc")
                    {
                        if (sortColumn == "UserName")
                        {

                            customerData = from x in customerData orderby x.FirstName ascending select x;
                        }
                        else if (sortColumn == "Date")
                        {
                            customerData = from x in customerData orderby x.CreatedDate ascending select x;
                        }
                        else if(sortColumn == "UserTypeId")
                        {
                            customerData = from x in customerData orderby x.UserTypeId ascending select x;
                        }
                        else if(sortColumn == "ZipCode")
                        {
                            customerData = from x in customerData orderby x.ZipCode ascending select x;
                        }else if(sortColumn == "Mobile")
                        {
                            customerData = from x in customerData orderby x.Mobile ascending select x;
                        }else if(sortColumn== "UserStatus")
                        {
                            customerData = from x in customerData orderby x.IsActive ascending select x;
                        }
                        else
                        {
                            customerData = from x in customerData orderby x.UserId ascending select x;
                        }
                    }
                    else if(sortColumnDirection=="desc")
                    {
                        if (sortColumn == "UserName")
                        {

                            customerData = from x in customerData orderby x.FirstName descending select x;
                        }
                        else if (sortColumn == "Date")
                        {
                            customerData = from x in customerData orderby x.CreatedDate descending select x;
                        }
                        else if (sortColumn == "UserTypeId")
                        {
                            customerData = from x in customerData orderby x.UserTypeId descending select x;
                        }
                        else if (sortColumn == "ZipCode")
                        {
                            customerData = from x in customerData orderby x.ZipCode descending select x;
                        }
                        else if (sortColumn == "Mobile")
                        {
                            customerData = from x in customerData orderby x.Mobile descending select x;
                        }
                        else if (sortColumn == "UserStatus")
                        {
                            customerData = from x in customerData orderby x.IsActive descending select x;
                        }
                        else
                        {
                            customerData = from x in customerData orderby x.UserId descending select x;
                        }
                    }
                   
                 
                }
                if (Admindata.UserName != null)
                {
                    var list = Admindata.UserName.Split(" ");
                    if (list.Length == 2)
                    {
                        customerData = customerData.Where(x => (x.FirstName.Contains(list[0]) && x.LastName.Contains(list[1])) ||(x.FirstName.Contains(list[1]) && x.LastName.Contains(list[0])));
                        
                    }
                    else
                    {
                        customerData = customerData.Where(x => x.FirstName.Contains(Admindata.UserName) || x.LastName.Contains(Admindata.UserName));
                    }
                    
                }

                if (Admindata.UserType != null)
                {
                    if (Admindata.UserType == "1")
                    {
                        customerData = customerData.Where(x => x.UserTypeId == 1);
                    }
                    else if (Admindata.UserType == "2")
                    {
                        customerData = customerData.Where(x => x.UserTypeId == 2);
                    }
                    else if (Admindata.UserType == "3")
                    {
                        customerData = customerData.Where(x => x.UserTypeId == 3);
                    }
                }

                if (Admindata.Mobile != null)
                {
                    customerData = customerData.Where(x => x.Mobile.Contains(Admindata.Mobile));
                }

                if (Admindata.PostalCode != null)
                {
                    customerData = customerData.Where(x => x.ZipCode.Contains(Admindata.PostalCode));
                }
                if(Admindata.Email != null)
                {
                    customerData = customerData.Where(x => x.Email.Contains(Admindata.Email));
                }
                if (Admindata.FromDate != null && Admindata.ToDate != null)
                {
                    customerData = customerData.Where(x => (x.CreatedDate >= DateTime.Parse(Admindata.FromDate)) && (x.CreatedDate <= DateTime.Parse(Admindata.ToDate).AddDays(1)));
                }
                recordsTotal = customerData.Count();
               var Tempdata = customerData.Skip(skip).Take(pageSize).ToList();
                List<AdminUserList> data = new List<AdminUserList>();
                for(int i=0;i<Tempdata.Count();i++)
                {
                    AdminUserList aul = new AdminUserList();
                    UserAddress uaddr = _db.UserAddresses.FirstOrDefault(x => x.UserId == Tempdata[i].UserId);

                    aul.UserId = Tempdata[i].UserId;
                    aul.UserName = Tempdata[i].FirstName + " " + Tempdata[i].LastName;
                    aul.PostalCode = Tempdata[i].ZipCode;
                    aul.Date = Tempdata[i].CreatedDate.ToString("dd/MM/yyyy");
                    aul.Mobile = Tempdata[i].Mobile;
                    if (Tempdata[i].UserTypeId == 1)
                    {
                        aul.UserType = "Customer";
                    }
                    else if(Tempdata[i].UserTypeId== 2)
                    {
                        aul.UserType = "Service Provider";
                    }else if (Tempdata[i].UserTypeId == 3)
                    {
                        aul.UserType = "Admin";
                    }
                    aul.UserStatus = Tempdata[i].IsActive;

                    if(uaddr!=null)
                         aul.City = uaddr.City;

                    data.Add(aul);

                   
                }
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            return Ok(Json("false"));
        }



        [HttpPost]
        public IActionResult GetSeviceList(CustomerNewServiceRequest Admindata)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
            if (Id != null)
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;


                var customerData = (from x in _db.ServiceRequests select x);

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    if (sortColumnDirection == "asc")
                    {
                        if (sortColumn == "serviceRequestId")
                        {

                            customerData = from x in customerData orderby x.ServiceRequestId ascending select x;
                        }
                        else if (sortColumn == "CustomerName")
                        {
                            customerData = from x in customerData join y in _db.Users on x.UserId equals y.UserId orderby y.FirstName ascending select x;
                        }else if(sortColumn == "Date")
                        {
                            customerData = from x in customerData orderby x.ServiceStartDate ascending select x;
                        }
                        else if (sortColumn == "TotalCost")
                        {
                            customerData = from x in customerData orderby x.TotalCost ascending select x;
                        }
                        else if (sortColumn == "ServiceProvider")
                        {
                            customerData = from x in customerData orderby x.ServiceProvider.FirstName ascending select x; 
                        }
                        else if (sortColumn == "UserStatus")
                        {
                            customerData = customerData.OrderBy(x=>x.Status).ThenBy(x=>x.ServiceProviderId);
                        }
                        else
                        {
                            customerData = from x in customerData orderby x.ServiceRequestId ascending select x;
                        }
                    }
                    else if (sortColumnDirection == "desc")
                    {
                        if (sortColumn == "serviceRequestId")
                        {

                            customerData = from x in customerData orderby x.ServiceRequestId descending select x;
                        }
                        else if (sortColumn == "Date")
                        {
                            customerData = from x in customerData orderby x.ServiceStartDate descending select x;
                        }
                        else if (sortColumn == "CustomerName")
                        {
                            customerData = from x in customerData join y in _db.Users on x.UserId equals y.UserId orderby y.FirstName descending select x;
                        }
                        else if (sortColumn == "TotalCost")
                        {
                            customerData = from x in customerData orderby x.TotalCost descending select x;
                        }
                        else if (sortColumn == "ServiceProvider")
                        {
                            customerData = from x in customerData orderby x.ServiceProvider.FirstName descending select x;
                        }
                        else if (sortColumn == "UserStatus")
                        {
                            customerData = customerData.OrderByDescending(x => x.Status).ThenByDescending(x => x.ServiceProviderId);
                        }
                        else
                        {
                            customerData = from x in customerData orderby x.ServiceRequestId descending select x;
                        }
                    }


                }


                if (Admindata.ServiceRequestId != 0)
                {
                    customerData = customerData.Where(x =>x.ServiceRequestId == Admindata.ServiceRequestId);
                }

                if (Admindata.CustomerName != null)
                {
                    customerData = customerData.Where(x => x.User.FirstName.Contains(Admindata.CustomerName));
                }

                if (Admindata.ServiceProvider != null)
                {
                    customerData = customerData.Where(x => x.ServiceProvider.FirstName.Contains(Admindata.ServiceProvider));
                }

                if (Admindata.FromDate != null && Admindata.ToDate != null)
                {
                    customerData = customerData.Where(x => (x.ServiceStartDate >= DateTime.Parse(Admindata.FromDate)) && (x.ServiceStartDate <= DateTime.Parse(Admindata.ToDate).AddDays(1)));
                }

                if(Admindata.postalCode != null)
                {
                    customerData = customerData.Where(x => x.ZipCode.Contains(Admindata.postalCode));
                }

                if (Admindata.email != null)
                {
                    customerData = customerData.Where(x => x.ZipCode.Contains(Admindata.email));
                }

                if (Admindata.Status != null)
                {
                    if(Admindata.Status == 0)
                    {
                        customerData = customerData.Where(x => x.Status ==0);
                    }else if(Admindata.Status == 1)
                    {
                        customerData = customerData.Where(x => x.Status == 1);

                    }else if(Admindata.Status == 3)
                    {
                        customerData = customerData.Where(x => x.Status == 2 && x.ServiceProviderId==null);
                    }else if(Admindata.Status == 2)
                    {
                        customerData = customerData.Where(x => x.Status == 2 && x.ServiceProviderId != null);
                    }
                    
                }




                recordsTotal = customerData.Count();
                var Tempdata = customerData.Skip(skip).Take(pageSize).ToList();

                List<CustomerNewServiceRequest> data = new List<CustomerNewServiceRequest>();

                

                for(int i = 0; i < Tempdata.Count(); i++)
                {

                    CustomerNewServiceRequest sr = new CustomerNewServiceRequest();
                    sr.ServiceRequestId = Tempdata[i].ServiceRequestId;
                    sr.ServiceStartDate = Tempdata[i].ServiceStartDate.ToString("dd/MM/yyyy");
                    sr.startTime = Tempdata[i].ServiceStartDate.ToString("HH:mm");
                    sr.endTime = Tempdata[i].ServiceStartDate.AddHours((double)Tempdata[i].SubTotal).ToString("HH:mm");
                    sr.TotalCost = Tempdata[i].TotalCost;
                    User customer = _db.Users.FirstOrDefault(x => x.UserId == Tempdata[i].UserId);
                    sr.CustomerName = customer.FirstName + " " + customer.LastName;
                    UserAddress customerAddr = _db.UserAddresses.FirstOrDefault(x => x.UserId == Tempdata[i].UserId && x.IsDefault == true);
                    sr.CustomerAddress1 = customerAddr.AddressLine1 + " " + customerAddr.AddressLine2;
                    sr.CustomerAddress2 = customerAddr.PostalCode + " " + customerAddr.City;
                    sr.Status = Tempdata[i].Status;
                    if (Tempdata[i].ServiceProviderId != null)
                    {
                        User sp = _db.Users.Where(x => x.UserId == Tempdata[i].ServiceProviderId).FirstOrDefault();

                        sr.ServiceProvider = sp.FirstName + " " + sp.LastName;



                        var rating = _db.Ratings.Where(x => x.RatingTo == Tempdata[i].ServiceProviderId);

                        if (rating.Count() > 0)
                        {

                            sr.SPRatings = Math.Round(rating.Average(x => x.Ratings), 1);
                        }



                    }

                    data.Add(sr);
                }
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            return Ok(Json("false"));
        }


        public IActionResult ActiveDeactiveUser(User user)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
            if (Id != null)
            {
                User u = _db.Users.FirstOrDefault(x => x.UserId == user.UserId);

                if (u.IsActive)
                {
                    u.IsActive = false;
                }
                else
                {
                    u.IsActive = true;
                }
                u.ModifiedBy = (int)Id;
                u.ModifiedDate = DateTime.Now;
                _db.Users.Update(u);
                _db.SaveChanges();

                return Ok(Json("true"));
            }
            return Ok(Json("false"));
        }




        public JsonResult showServiceRequestSummery(ServiceRequest data)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
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
                
                Details.PostalCode = requestAddress.PostalCode;

                User customerName = _db.Users.Where(x => x.UserId == request.UserId).FirstOrDefault();

                Details.ServiceProviderName = customerName.FirstName + " " + customerName.LastName;
                Details.Email = customerName.Email;






                return new JsonResult(Details);
            }

            return new JsonResult("false");

        }



        [HttpPost]
        public IActionResult CancelServiceRequest(ServiceRequest data)
        {

            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
            if (Id != null)
            {
                ServiceRequest serviceRequestCancel = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == data.ServiceRequestId);

                if (serviceRequestCancel != null)
                {
                    serviceRequestCancel.Status = 1;
                    _db.ServiceRequests.Update(serviceRequestCancel);
                    _db.SaveChanges();

                    var ServiceProviderList = _db.Users.Where(x => x.UserId == serviceRequestCancel.ServiceProviderId || x.UserId == serviceRequestCancel.UserId).ToList();
                   
                    string message = "<p>Service Request " + serviceRequestCancel.ServiceRequestId + " has been cancel by admin</p>";

                    Task task = Task.Run(() => SendMain(ServiceProviderList, message, "cancel service"));

                    return Ok(Json("true"));

                }
                
            }

            return Ok(Json("false"));
        }

        private static void SendMain(List<User> ServiceProviderList, string message, string subject)
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


        [HttpGet]
        public JsonResult GetEditServiceRequestData(ServiceRequest request)
        {

            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
            if (Id != null)
            {
                ServiceRequest showRequest = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == request.ServiceRequestId);
                AdminServiceRequestUpdate sr = new AdminServiceRequestUpdate();
                if (showRequest != null)
                {
                   
                    sr.ServiceRequestId = showRequest.ServiceRequestId;
                    sr.ServiceStartDate = showRequest.ServiceStartDate;
                    
                   

                }
                if (showRequest.ServiceProviderId != null)
                {
                    sr.IsTaken = true;
                }
                else
                {
                    sr.IsTaken = false;
                }

                ServiceRequestAddress sraddr = _db.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == request.ServiceRequestId);

                if (sraddr != null)
                {
                    sr.StreetName = sraddr.AddressLine2;
                    sr.HouseNumber = sraddr.AddressLine1;
                    sr.PostalCode = sraddr.PostalCode;
                    sr.City = sraddr.City;
                    sr.State = sraddr.State;
                    return new JsonResult(sr);
                }

                
            }

            return new JsonResult("false");
        }


        [HttpPost]
         public IActionResult UpdateServiceRequest(AdminServiceRequestUpdate request)
        {

            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
            if (Id != null)
            {
                ServiceRequest srRequest = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == request.ServiceRequestId);

                if (srRequest != null)
                {
                    if (srRequest.ServiceProviderId != null)
                    {
                        var thistimeStart = DateTime.Parse(request.ServiceStartDate.ToString("M/d/yyyy") + " " + request.StartTime.ToString("HH:mm"));
                        var thistimeEnd = thistimeStart.AddHours((double)srRequest.SubTotal + 1);
                        ServiceRequest conflictService = _db.ServiceRequests.FirstOrDefault(
                            x => x.Status == 2 && (x.ServiceProviderId == srRequest.ServiceProviderId && x.ServiceStartDate <= thistimeStart && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) >= thistimeStart) || (x.ServiceProviderId == srRequest.ServiceProviderId && x.ServiceStartDate <= thistimeEnd && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) >= thistimeEnd) || (x.ServiceProviderId == srRequest.ServiceProviderId && x.ServiceStartDate >= thistimeStart && x.ServiceStartDate.AddHours((double)x.SubTotal + 1) <= thistimeEnd)
                            );

                        if (conflictService != null)
                        {
                            return Ok(Json("conflict"));
                        }
                    }
                    srRequest.ServiceStartDate = DateTime.Parse(request.ServiceStartDate.ToString("M/d/yyyy") + " " + request.StartTime.ToString("HH:mm"));
                    srRequest.Comments = request.Comment;
                    srRequest.ModifiedDate = DateTime.Now;
                    srRequest.ModifiedBy = (int)Id;
                    srRequest.ZipCode = request.PostalCode;
                    _db.Update(srRequest);
                    _db.SaveChanges();

                    ServiceRequestAddress srAddr = _db.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == request.ServiceRequestId);

                    if (srAddr != null)
                    {
                        srAddr.AddressLine1 = request.HouseNumber;
                        srAddr.AddressLine2 = request.StreetName;
                        srAddr.PostalCode = request.PostalCode;
                        srAddr.City = request.City;

                        _db.ServiceRequestAddresses.Update(srAddr);
                        _db.SaveChanges();

                        var ServiceProviderList = _db.Users.Where(x => x.UserId == srRequest.ServiceProviderId || x.UserId == srRequest.UserId).ToList();

                        string message = "<p>Service Request " + srRequest.ServiceRequestId + " has been update by addmin</p>";

                        Task task = Task.Run(() => SendMain(ServiceProviderList, message, "Reschedule service"));

                        return Ok(Json("true"));
                    }

                }

              

               

            }

            return Ok(Json("false"));
        }


        [HttpGet]
        public JsonResult GetZipcodeCity(User user)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }

            if (Id != null)
            {
                User isThereZip = _db.Users.FirstOrDefault(x => x.UserTypeId == 2 && x.ZipCode == user.ZipCode);
                if (isThereZip != null)
                {
                    UserAddress userAddr = _db.UserAddresses.FirstOrDefault(x => x.UserId == isThereZip.UserId);
                    if (userAddr != null)
                    {
                        AddressDetails addrDetails = new AddressDetails();
                        addrDetails.City = userAddr.City;
                        addrDetails.State = userAddr.State;

                        return new JsonResult(addrDetails);
                    }

                }

            }
            return new JsonResult("false");
        }

        [HttpGet]
        public JsonResult PayInfo(ServiceRequest sr)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
            if (Id != null)
            {
                ServiceRequest payInfo = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == sr.ServiceRequestId);
                if (payInfo != null)
                {
                    var info = new {pay = payInfo.TotalCost};

                    return new JsonResult(info);
                }

            }
            return new JsonResult("false");
        }

        [HttpPost]
        public IActionResult RefundMoney(ServiceRequest request)
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id == null && Request.Cookies["userid"] != null)
            {
                HttpContext.Session.SetInt32("id", Convert.ToInt32(Request.Cookies["userid"]));
                Id = HttpContext.Session.GetInt32("id");
            }
            if (Id != null)
            {
                ServiceRequest IsRefund = _db.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == request.ServiceRequestId );

                if (IsRefund != null)
                {
                 if(IsRefund.RefundedAmount != null)
                    {
                        return Ok(Json("alreadyRefund"));
                    }
                    else
                    {
                        if (request.RefundedAmount > IsRefund.TotalCost)
                        {
                            return Ok(Json("tooHigh"));
                        }
                        else
                        {
                            IsRefund.RefundedAmount = request.RefundedAmount;
                            IsRefund.Comments = request.Comments;
                            _db.Update(IsRefund);
                            _db.SaveChanges();
                            return Ok(Json("true"));
                        }
                        
                    }
                }
            }

            return Ok(Json("false"));
        }
    }
}
