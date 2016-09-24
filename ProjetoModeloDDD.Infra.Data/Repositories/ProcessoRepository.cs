using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ProcessoRepository : RepositoryBase<Processo>, IProcessoRepository
    {
        public IEnumerable<Processo> BuscarPorNumeroProcesso(string numero)
        {
            return Db.Processos.Where(p => p.numeroProcesso == numero);
        }
    }
}
