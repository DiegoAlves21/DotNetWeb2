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
    public class AutoInfracaoController : Controller
    {

        private readonly IAutoInfracaoAppService _autoInfracaoApp;

        public AutoInfracaoController(IAutoInfracaoAppService autoInfracaoApp)
        {
            _autoInfracaoApp = autoInfracaoApp;
        }

        // GET: AutoInfracao
        public ActionResult Index()
        {
            var autoInfracaoViewModel = Mapper.Map<IEnumerable<AutoInfracao>, IEnumerable<AutoInfracaoViewModel>>(_autoInfracaoApp.GetAll());
            return View(autoInfracaoViewModel);
        }

        // GET: AutoInfracao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutoInfracao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutoInfracaoViewModel autoInfracao)
        {
            var autoInfracaoDomain = Mapper.Map<AutoInfracaoViewModel, AutoInfracao>(autoInfracao);
            _autoInfracaoApp.Add(autoInfracaoDomain);

            return View(autoInfracao);
        }
    }
}