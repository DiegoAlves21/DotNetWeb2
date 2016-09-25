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
        private readonly IFornecedorAppService _fornecedorApp;
        private readonly IEnderecoAppService _enderecoApp;

        public ProcessoController(IProcessoAppService processoApp, IFornecedorAppService fornecedorApp, IEnderecoAppService enderecoApp)
        {
            _processoApp = processoApp;
            _fornecedorApp = fornecedorApp;
            _enderecoApp = enderecoApp;
        }

        // GET: Processo
        public ActionResult Index()
        {
            var processoViewModel = Mapper.Map<IEnumerable<Processo>, IEnumerable<ProcessoViewModel>>(_processoApp.GetAll());
            return View(processoViewModel);
        }

        // GET: Processo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Processo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProcessoViewModel processo, FornecedorViewModel fornecedor)
        {
            processo.numeroProcesso = GerarNumeroPorcesso(processo.Fornecedor.Cnpj);
            var processoDomain = Mapper.Map<ProcessoViewModel, Processo>(processo);
            _processoApp.Add(processoDomain);

            return RedirectToAction("Index");
        }

        // POST: Processo/FornecedorInfo
        [HttpGet]
        public ActionResult FornecedorInfo(string CNPJ)
        {
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.BuscarPorCnpj(CNPJ).SingleOrDefault());
            var enderecoViewModel = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoApp.GetById(fornecedorViewModel.EnderecoId));
            fornecedorViewModel.Endereco = enderecoViewModel;
            return PartialView(fornecedorViewModel);
        }

        // GET: Processo/GerarAutoInfracao
        public ActionResult GerarAutoInfracao(int ProcessoId)
        {
            //var processoViewModel = Mapper.Map<Processo, ProcessoViewModel>(_processoApp.GetById(ProcessoId));
            return View("~/Views/AutoInfracao/Create.cshtml");
        }

        private string GerarNumeroPorcesso(string CNPJ)
        {
            string ano = System.DateTime.Now.Year.ToString();
            string mes = System.DateTime.Now.Month.ToString();
            string dia = System.DateTime.Now.Day.ToString();

            string hora = System.DateTime.Now.Hour.ToString();
            string minutos = System.DateTime.Now.Minute.ToString();
            string segundos = System.DateTime.Now.Second.ToString();

            return ano + mes + dia + "-" + hora + minutos + segundos + "-" + CNPJ;
        }
    }
}