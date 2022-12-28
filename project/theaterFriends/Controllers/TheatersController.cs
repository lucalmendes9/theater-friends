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
    public class TheatersController : PadraoController<TheatersViewModel>
    {
        public TheatersController()
        {
           DAO = new TheatersDAO();
        }
        public override IActionResult Index(string table = "", string value = "", string option = "")
        {
            var lista = DAO.Listagem(value, option);
            return View(ViewParaListagem, lista);
        }

        protected override void PreencheDadosParaView(string Operacao, TheatersViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            PreencheComboBoxLocalizacao();
            model.Work_days = 7;
        }

        private void PreencheComboBoxLocalizacao()
        {
            var daoLocation = new LocalizationDAO();

            ViewBag.location = new List<SelectListItem>();
            ViewBag.location.Add(new SelectListItem("Selecione uma Localização...", "0"));

            foreach (LocalizationViewModel loc in daoLocation.Listagem())
            {
                var elemento = new SelectListItem(loc.City, loc.Id.ToString());
                ViewBag.location.Add(elemento);
            }
        }

        public override IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                var model = DAO.Consulta(id);

                if (model == null)
                    return RedirectToAction(ViewParaListagem);
                else
                {
                    var mdl = new LocalizationDAO().Consulta(model.Localization_id);
                    ViewBag.Phone = mdl.Phone;
                    ViewBag.Address = mdl.Address;
                    ViewBag.Number = mdl.Number;
                    ViewBag.Neighbourhood = mdl.Neighbourhood;
                    ViewBag.City = mdl.City;
                    ViewBag.State = mdl.State;

                    PreencheDadosParaView("A", model);
                    return View(ViewParaCadastro, model);
                }
            }
            catch
            {
                return RedirectToAction(ViewParaListagem);
            }
        }

        protected override void ValidaDados(TheatersViewModel model, string operacao)
        {
            if( operacao != "I" )
                base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Description))
                ModelState.AddModelError("Description", "Nome inválido!");

            if (model.Localization_id <= 0)
                ModelState.AddModelError("Localization_id", "Localização inválida!");
        }
    }
}
