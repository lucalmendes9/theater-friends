using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace theaterFriends.Controllers
{
    public class EmployerController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }
    }

}
