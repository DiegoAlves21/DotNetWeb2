using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IFornecedorService : IServiceBase<Fornecedor>
    {
        IEnumerable<Fornecedor> BuscarPorCnpj(string cnpj);
    }
}
