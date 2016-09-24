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
    public class ProcessoController : Controller
    {
        private readonly IProcessoAppService _processoApp;

        public ProcessoController(IProcessoAppService processoApp)
        {
            _processoApp = processoApp;
        }

        // GET: Processo
        public ActionResult Index()
        {
            var processoViewModel = Mapper.Map<IEnumerable<Processo>, IEnumerable<ProcessoViewModel>>(_processoApp.GetAll());
            return View(processoViewModel);
        }
    }
}