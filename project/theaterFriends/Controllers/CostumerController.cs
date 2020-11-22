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
        }

        protected override void ValidaDados(CostumerViewModel model, string operacao)
        {
            model.Created_At = DateTime.Now;

            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Name", "Nome inválido!");

            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("Email", "Email inválido!");

            if (string.IsNullOrEmpty(model.Password) || model.Password.Length < 7 )
                ModelState.AddModelError("Password", "Senha inválido (tamanho mínimo de 8 caracteres!");

            if (string.IsNullOrEmpty(model.ConfirmPassword) || model.ConfirmPassword.Length < 7 )
                ModelState.AddModelError("ConfirmPassword", "Senha inválido (tamanho mínimo de 8 caracteres!");

            if (model.Password != model.ConfirmPassword )
                ModelState.AddModelError("Password", "As senhas não batem!");
        }

        public override IActionResult Salvar(CostumerViewModel model, string Operacao)
        {
            try
            {
                ValidaDados(model, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    PreencheDadosParaView(Operacao, model);
                    return View(ViewParaCadastro, model);
                }
                else
                {
                    if (Operacao == "I")
                        DAO.Insert(model);
                    else
                        DAO.Update(model);
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                ViewBag.Operacao = Operacao;
                PreencheDadosParaView(Operacao, model);
                return View(ViewParaCadastro, model);
            }
        }
    }
}
