using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using theaterFriends.DAO;
using theaterFriends.Models;

namespace theaterFriends.Controllers
{
    public class LoginController : PadraoController<PadraoViewModel>
    {

        public override IActionResult Index()
        {
            return View();
        }
        public IActionResult FazLogin(string usuario, string senha)
        {
            var loginDAO = new LoginDAO();
            var respUser = loginDAO.Login(usuario, senha);

            if (respUser != null)
            {
                HttpContext.Session.SetString("Logado", "true");
                HttpContext.Session.SetString("Name", respUser.Name);
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }
    }
}
