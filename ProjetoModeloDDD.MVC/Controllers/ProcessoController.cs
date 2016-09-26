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

            foreach(ProcessoViewModel processo in processoViewModel)
            {
                processoViewModel.Where(p => p.FornecedorId == processo.FornecedorId).SingleOrDefault().Fornecedor = new FornecedorViewModel() { Cnpj = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.GetById(processo.FornecedorId)).Cnpj };
            }

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
        public ActionResult Create(ProcessoViewModel processo)
        {
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.BuscarPorCnpj(processo.Fornecedor.Cnpj).SingleOrDefault());
            //var enderecoViewModel = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoApp.GetById(fornecedorViewModel.EnderecoId));
            processo.numeroProcesso = GerarNumeroPorcesso(processo.Fornecedor.Cnpj);
            //fornecedorViewModel.Endereco = enderecoViewModel;
            //processo.Fornecedor = fornecedorViewModel;

            processo.Fornecedor = null;
            processo.FornecedorId = fornecedorViewModel.FornecedorId;
            //processo.Fornecedor.Endereco = new EnderecoViewModel() { EnderecoId = enderecoViewModel.EnderecoId };
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
        public ActionResult GerarAutoInfracao(int id)
        {
            var processoViewModel = Mapper.Map<Processo, ProcessoViewModel>(_processoApp.GetById(id));
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.GetById(processoViewModel.FornecedorId));
            var enderecoViewModel = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoApp.GetById(fornecedorViewModel.EnderecoId));
            processoViewModel.Fornecedor = fornecedorViewModel;
            processoViewModel.Fornecedor.Endereco = enderecoViewModel;
            AutoInfracaoViewModel autoInfracao = new AutoInfracaoViewModel() { processo = processoViewModel };
            return View("~/Views/AutoInfracao/Create.cshtml", autoInfracao);
        }

        // GET: Processo/Details
        public ActionResult Details(int id)
        {
            var processo = _processoApp.GetById(id);
            var processoViewModel = Mapper.Map<Processo, ProcessoViewModel>(processo);
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.GetById(processo.FornecedorId));
            var enderecoViewModel = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoApp.GetById(fornecedorViewModel.EnderecoId));
            fornecedorViewModel.Endereco = enderecoViewModel;
            processoViewModel.Fornecedor = fornecedorViewModel;
            return View(processoViewModel);
        }

        // GET: Processo/Edit/5
        public ActionResult Edit(int id)
        {
            var processo = _processoApp.GetById(id);
            var processoViewModel = Mapper.Map<Processo, ProcessoViewModel>(processo);
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.GetById(processo.FornecedorId));
            var enderecoViewModel = Mapper.Map<Endereco, EnderecoViewModel>(_enderecoApp.GetById(fornecedorViewModel.EnderecoId));
            fornecedorViewModel.Endereco = enderecoViewModel;
            processoViewModel.Fornecedor = fornecedorViewModel;
            return View(processoViewModel);
        }

        // POST: Processo/Edit/5
        [HttpPost]
        public ActionResult Edit(ProcessoViewModel processo)
        {
            if (ModelState.IsValid)
            {
                var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(_fornecedorApp.BuscarPorCnpj(processo.Fornecedor.Cnpj).SingleOrDefault());

                processo.Fornecedor = null;
                processo.FornecedorId = fornecedorViewModel.FornecedorId;

                var processoDomain = Mapper.Map<ProcessoViewModel, Processo>(processo);
                _processoApp.Update(processoDomain);

                return RedirectToAction("Index");
            }

            return View(processo);
        }

        // GET: Processo/Delete/5
        public ActionResult Delete(int id)
        {
            var processo = _processoApp.GetById(id);
            var processoViewModel = Mapper.Map<Processo, ProcessoViewModel>(processo);
            return View(processoViewModel);
        }

        // POST: Processo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var processo = _processoApp.GetById(id);
            _processoApp.Remove(processo);
            return RedirectToAction("Index");
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