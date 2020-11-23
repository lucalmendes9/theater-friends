using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using theaterFriends.DAO;
using theaterFriends.Models;

namespace theaterFriends.Controllers
{
    public class LocalizationController : PadraoController<LocalizationViewModel>
    {
        public LocalizationController()
        {
            DAO = new LocalizationDAO();
        }

        public override IActionResult Index(string table)
        {
            return View();
        }

        public virtual string SalvarAjax(LocalizationViewModel model, string Operacao)
        {
            try
            {
                var id = -1;
                if (Operacao == "I")
                    id = DAO.Insert(model);
                else
                    DAO.Update(model);
                return id.ToString();
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                ViewBag.Operacao = Operacao;
                PreencheDadosParaView(Operacao, model);
                return "error";
            }
        }
    }
}
