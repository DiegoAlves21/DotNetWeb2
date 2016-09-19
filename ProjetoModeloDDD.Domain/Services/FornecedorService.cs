using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Services
{
    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository) : base(fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public IEnumerable<Fornecedor> BuscarPorCnpj(string cnpj)
        {
            return _fornecedorRepository.BuscarPorCnpj(cnpj);
        }
    }
}
