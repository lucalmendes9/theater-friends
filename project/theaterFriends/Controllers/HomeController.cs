using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using theaterFriends.DAO;
using theaterFriends.Models;

namespace theaterFriends.Controllers
{
    public class HomeController : PadraoController<MoviesViewModel>
    {
        TheatersDAO DAOT = new TheatersDAO();
        public IActionResult Main()
        {
            ViewBag.lista = DAOT.Listagem();
            var lista = DAO.Listagem();
            return View(lista);
        }

        public HomeController()
        {
            DAO = new MoviesDAO();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Metodo sobrescrito pois as telas dessa controler podem ser acessadas sem login
        }
    }
}