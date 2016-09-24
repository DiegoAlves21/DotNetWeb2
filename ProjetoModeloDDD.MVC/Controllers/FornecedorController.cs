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



    }
}