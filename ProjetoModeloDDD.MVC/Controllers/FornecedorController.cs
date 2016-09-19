using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorAppService _fornecedorApp;

        public FornecedorController(IFornecedorAppService fornecedorApp)
        {
            _fornecedorApp = fornecedorApp;
        }

        // GET: Fornecedor
        public ActionResult Index()
        {
            var fornecedorViewModel = Mapper.Map<IEnumerable<Fornecedor>, IEnumerable<FornecedorViewModel>>(_fornecedorApp.GetAll());
            return View(fornecedorViewModel);
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int id)
        {
            var fornecedor = _fornecedorApp.GetById(id);
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(fornecedor);
            return View(fornecedorViewModel);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorViewModel fornecedor)
        {
            var fornecedorDomain = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedor);
            _fornecedorApp.Add(fornecedorDomain);

            return RedirectToAction("Index");
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int id)
        {
            var fornecedor = _fornecedorApp.GetById(id);
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(fornecedor);
            return View(fornecedorViewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(FornecedorViewModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                var fornecedorDomain = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedor);
                _fornecedorApp.Update(fornecedorDomain);

                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int id)
        {
            var fornecedor = _fornecedorApp.GetById(id);
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(fornecedor);
            return View(fornecedorViewModel);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var fornecedor = _fornecedorApp.GetById(id);
            _fornecedorApp.Remove(fornecedor);
            return RedirectToAction("Index");
        }
    }
}