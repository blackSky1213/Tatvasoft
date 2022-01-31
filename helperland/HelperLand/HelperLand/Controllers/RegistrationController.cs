using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperLand.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult SignUp()
        {
            return PartialView();
        }
    }
}
