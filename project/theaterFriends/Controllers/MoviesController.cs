using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using theaterFriends.DAO;
using theaterFriends.Models;

namespace theaterFriends.Controllers
{
    public class MoviesController : PadraoController<MoviesViewModel>
    {
        public MoviesController()
        {
            DAO = new MoviesDAO();
        }

        public IActionResult Views()
        {
            return View();
        }

        protected override void ValidaDados(MoviesViewModel model, string operacao)
        {
            //base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Name", "Nome inválido!");

            if (string.IsNullOrEmpty(model.Description))
                ModelState.AddModelError("Description", "Descrição inválida!");

            if (string.IsNullOrEmpty(model.Type))
                ModelState.AddModelError("Type", "Tipo inválida!");

            if (model.Length <= 0)
            {
                ModelState.Remove("Length");
                ModelState.AddModelError("Length", "Duração Invalida");
            } 

            if (model.Min_age < 0 || model.Min_age > 18)
            {
                ModelState.Remove("Min_Age");
                ModelState.AddModelError("Min_age", "Idade mínima deve estar entre 0 e 18");
            }

            if (string.IsNullOrEmpty(model.Language))
                ModelState.AddModelError("Language", "Linguagem inválida!");
        }
    }
}
