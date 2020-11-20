﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using theaterFriends.DAO;
using theaterFriends.Models;

namespace theaterFriends.Controllers
{
    public abstract class PadraoController<T> : Controller where T : PadraoViewModel
    {
        protected PadraoDAO<T> DAO { get; set; }
        protected bool SugereProximoId { get; set; }

        protected string ViewParaListagem { get; set; } = "Index";
        protected string ViewParaCadastro { get; set; } = "Form";


        public virtual IActionResult Form()
        {
            return View();
        }
        public virtual IActionResult Index()
        {
            var lista = DAO.Listagem();
            return View(ViewParaListagem, lista);
        }

        public virtual IActionResult Create()
        {
            ViewBag.Operacao = "I";
            T model = Activator.CreateInstance(typeof(T)) as T;
            PreencheDadosParaView("I", model);
            return View(ViewParaCadastro, model);
        }
        protected virtual void PreencheDadosParaView(string Operacao, T model)
        {
            //if (SugereProximoId && Operacao == "I")
            //    model.Id = DAO.ProximoId();
        }
        public virtual IActionResult Salvar(T model, string Operacao)
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
                    return RedirectToAction(ViewParaListagem);
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
        protected virtual void ValidaDados(T model, string operacao)
        {
            if (operacao == "I" && DAO.Consulta(model.Id) != null)
                ModelState.AddModelError("Id", "Código já está em uso!");
            if (operacao == "A" && DAO.Consulta(model.Id) == null)
                ModelState.AddModelError("Id", "Este registro não existe!");
            if (model.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");

        }
        public virtual IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                var model = DAO.Consulta(id);
                if (model == null)
                    return RedirectToAction(ViewParaListagem);
                else
                {
                    PreencheDadosParaView("A", model);
                    return View(ViewParaCadastro, model);
                }
            }
            catch
            {
                return RedirectToAction(ViewParaListagem);
            }
        }
        public virtual IActionResult Delete(int id)
        {
            try
            {
                DAO.Delete(id);
                return RedirectToAction(ViewParaListagem);
            }
            catch
            {
                return RedirectToAction(ViewParaListagem);
            }
        }
    }
}
