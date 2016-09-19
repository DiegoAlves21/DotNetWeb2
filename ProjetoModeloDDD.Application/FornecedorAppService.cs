using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application
{
    public class FornecedorAppService : AppServiceBase<Fornecedor>, IFornecedorAppService
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorAppService(IFornecedorService FornecedorService) : base(FornecedorService)
        {
            _fornecedorService = FornecedorService;
        }

        public IEnumerable<Fornecedor> BuscarPorCnpj(string cnpj)
        {
            return _fornecedorService.BuscarPorCnpj(cnpj);
        }
    }
}
