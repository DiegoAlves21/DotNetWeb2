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
        private readonly IProcessoAppService _processoApp;
        private readonly IFornecedorAppService _fornecedorApp;
        private readonly IEnderecoAppService _enderecoApp;

        public AutoInfracaoController(IAutoInfracaoAppService autoInfracaoApp, IProcessoAppService processoApp, IFornecedorAppService fornecedorApp, IEnderecoAppService enderecoApp)
        {
            _autoInfracaoApp = autoInfracaoApp;
            _processoApp = processoApp;
            _fornecedorApp = fornecedorApp;
            _enderecoApp = enderecoApp;
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
            autoInfracao.processo = null;
            autoInfracao.multa = CalculaMulta(autoInfracao);
            var autoInfracaoDomain = Mapper.Map<AutoInfracaoViewModel, AutoInfracao>(autoInfracao);
            _autoInfracaoApp.Add(autoInfracaoDomain);
            
            return RedirectToAction("Details", autoInfracao);
        }

        // GET: AutoInfracao/Details
        public ActionResult Details(AutoInfracaoViewModel autoInfracao)
        {
            var processoViewModel = Mapper.Map<Processo, ProcessoViewModel>(_processoApp.GetById(autoInfracao.ProcessoId));
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.GetById(processoViewModel.FornecedorId));
            var enderecoViewModel = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoApp.GetById(fornecedorViewModel.EnderecoId));
            fornecedorViewModel.Endereco = enderecoViewModel;
            processoViewModel.Fornecedor = fornecedorViewModel;
            autoInfracao.processo = processoViewModel;
            return View(autoInfracao);
        }

        private string CalculaMulta(AutoInfracaoViewModel autoInfracao)
        {
            var ag = (autoInfracao.agravante == true) ? 1 : 0;
            var at = (autoInfracao.atenuante == true) ? 0.33 : 1;

            var multa = 500 + (((120000) * 0.10) + 120000) * (3*(ag + at)*autoInfracao.gravidade);

            return multa.ToString();
        }

    }
}