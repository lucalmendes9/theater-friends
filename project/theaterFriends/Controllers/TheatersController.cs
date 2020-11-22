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

        protected override void PreencheDadosParaView(string Operacao, TheatersViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            PreencheComboBoxLocalizacao();
            model.Work_days = 0;
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

        protected override void ValidaDados(TheatersViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Description))
                ModelState.AddModelError("Description", "Descrição inválida!");

            if (model.Location_id <= 0)
                ModelState.AddModelError("Location_id", "Localização inválida!");
        }
    }
}
