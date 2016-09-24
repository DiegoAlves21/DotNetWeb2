using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IAutoInfracaoAppService : IAppServiceBase<AutoInfracao>
    {

        IEnumerable<AutoInfracao> BuscarPorGravidade(int gravidade);

    }
}
