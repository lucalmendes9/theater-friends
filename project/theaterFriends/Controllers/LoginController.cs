using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using theaterFriends.DAO;
using theaterFriends.Models;

namespace theaterFriends.Controllers
{
    public class LoginController : PadraoController<PadraoViewModel>
    {

        public override IActionResult Index(string table, string value = "", string option = "")
        {
            ViewBag.table = table;
            if (TempData["table"] != null)
                ViewBag.table = TempData["table"].ToString();
            if (TempData["Erro"] != null)
                ViewBag.Erro = TempData["Erro"].ToString();

            return View();
        }
        public IActionResult FazLogin(string usuario, string senha, string table)
        {
            var loginDAO = new LoginDAO();
            var respUser = loginDAO.Login(usuario, senha, table);

            if (respUser != null)
            {
                HttpContext.Session.SetString("Logado", "true");
                HttpContext.Session.SetString("Name", respUser.Name);
                HttpContext.Session.SetString("Type", table == "Employer" ? "Employer" : "Costumer");
                return RedirectToAction("Main", table == "Employer" ? "Administracao" : "Home");
            }
            else
            {
                TempData["Erro"] = "Usuário ou senha inválidos!";
                TempData["table"] = table;
                return RedirectToAction("index", "Login");
            }
        }
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Main", "Home");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Metodo sobrescrito pois as telas dessa controler podem ser acessadas sem login
        }
    }
}
