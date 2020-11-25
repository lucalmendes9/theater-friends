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
    public class RoomsController : PadraoController<RoomsViewModel>
    {
        public RoomsController()
        {
            DAO = new RoomsDAO();
        }
        public override IActionResult Index(string table = "", string value = "", string option = "")
        {
            var lista = DAO.Listagem(value, option);
            return View(ViewParaListagem, lista);
        }

        protected override void PreencheDadosParaView(string Operacao, RoomsViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            FillComboBoxTheaters();
        }

        private void FillComboBoxTheaters()
        {
            var daoTheaters = new TheatersDAO();
            ViewBag.Theaters = new List<SelectListItem>();
            ViewBag.Theaters.Add(new SelectListItem("Selecione um cinema...", "0"));
            foreach (TheatersViewModel t in daoTheaters.Listagem())
            {
                var elemento = new SelectListItem(t.Description, t.Id.ToString());
                ViewBag.Theaters.Add(elemento);
            }
        }

        protected override void ValidaDados(RoomsViewModel model, string operacao)
        {
            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Name", "Nome inválido!");

            if (model.Seats < 10 || model.Seats > 100)
                ModelState.AddModelError("Seats", "Assentos inválidos (Mín 10 , Máx 100!)");

            if (model.Theaters_id <= 0)
            {
                ModelState.AddModelError("Theaters_id", "Código de cinema inválido!");
            }

        }
    }
}

