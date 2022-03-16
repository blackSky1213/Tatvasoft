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
                    customerData = customerData.Where(x => x.FirstName.Contains(Admindata.UserName) || x.LastName.Contains(Admindata.UserName));
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
                
                if (Admindata.FromDate != null && Admindata.ToDate!=null)
                {
                    customerData = customerData.Where(x => (x.ServiceStartDate>=DateTime.Parse(Admindata.FromDate)) && (x.ServiceStartDate<=DateTime.Parse(Admindata.ToDate)));
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

        }
}
