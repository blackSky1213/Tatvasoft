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


        public IActionResult GetUserList()
        {
            int? Id = HttpContext.Session.GetInt32("id");
            if (Id != null)
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var customerData =_db.Users ;

              /*  if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                }*/
                /*if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.FirstName.Contains(searchValue)
                                                || m.LastName.Contains(searchValue)
                                                || m.Contact.Contains(searchValue)
                                                || m.Email.Contains(searchValue));
                }*/
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
    }
}
