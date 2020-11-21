using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace theaterFriends.Controllers
{
    public class TheatersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
