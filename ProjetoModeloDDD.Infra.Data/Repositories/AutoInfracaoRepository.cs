using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class AutoInfracaoRepository : RepositoryBase<AutoInfracao>, IAutoInfracaoRepository
    {

        public IEnumerable<AutoInfracao> BuscarPorGravidade(int gravidade)
        {
            return Db.AutoInfracoes.Where(p => p.gravidade == gravidade);
        }
        
    }
}
