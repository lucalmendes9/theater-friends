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

        
        public IActionResult Views(string id)
        {
            var list = DAO.ConsultaHorario(Convert.ToInt32(id));
            var movie = DAO.Consulta(Convert.ToInt32(id));
            ViewBag.Name = movie.Name;
            ViewBag.Description = movie.Description;
            ViewBag.Image = movie.ImagemEmBase64;
            ViewBag.Type = movie.Type;
            ViewBag.Min_age = movie.Min_age;
            ViewBag.Language = movie.Language;

            return View("Views", list);
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
                ModelState.AddModelError("Min_age", "Idade mínima deve estar entre 0 e 18)");
            }

            if (string.IsNullOrEmpty(model.Language))
                ModelState.AddModelError("Language", "Linguagem inválida!");

            if (model.Imagem == null && operacao == "I")
                ModelState.AddModelError("Imagem", "Escolha uma imagem.");

            if (ModelState.IsValid)
            {
                //na alteração, se não foi informada a imagem, iremos manter a que já estava salva.
                if (operacao == "A" && model.Imagem == null)
                {
                    MoviesViewModel mov = DAO.Consulta(model.Id);
                    model.ImagemEmByte = mov.ImagemEmByte;
                }
                else
                {
                    model.ImagemEmByte = HelperController.ConvertImageToByte(model.Imagem);
                }
            }
        }
    }
}
