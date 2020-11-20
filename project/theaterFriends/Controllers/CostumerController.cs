using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using theaterFriends.DAO;
using theaterFriends.Models;

namespace theaterFriends.Controllers
{
    public class CostumerController : PadraoController<CostumerViewModel>
    {
        public CostumerController()
        {
            DAO = new CostumerDAO();
        }

        protected override void PreencheDadosParaView(string Operacao, CostumerViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            if (Operacao == "I")
                model.Created_At = DateTime.Now;
        }

        /*private void PreencheComboBoxCidade()
        {
            var daoCidade = new CidadeDAO();

            ViewBag.cidades = new List<SelectListItem>();
            ViewBag.cidades.Add(new SelectListItem("Selecione uma cidade...", "0"));

            foreach (CidadeViewModel cid in daoCidade.Listagem())
            {
                var elemento = new SelectListItem(cid.Nome, cid.Id.ToString());
                ViewBag.cidades.Add(elemento);
            }
        }*/

        protected override void ValidaDados(CostumerViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Name", "Nome inválido!");

            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("Email", "Email inválido!");

            if (model.Password.Length < 7 || string.IsNullOrEmpty(model.Password))
                ModelState.AddModelError("Password", "Senha inválido (tamanho mínimo de 8 caracteres!");
        }
    }
}
