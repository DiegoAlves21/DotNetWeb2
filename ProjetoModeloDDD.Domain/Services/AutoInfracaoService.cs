using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class AutoInfracaoService : ServiceBase<AutoInfracao>, IAutoInfracaoService
    {

        private readonly IAutoInfracaoRepository _autoInfracaoRepository;

        public AutoInfracaoService(IAutoInfracaoRepository autoInfracaoRepository) : base(autoInfracaoRepository)
        {
            _autoInfracaoRepository = autoInfracaoRepository;
        }
        public IEnumerable<AutoInfracao> BuscarPorGravidade(int gravidade)
        {
            return _autoInfracaoRepository.BuscarPorGravidade(gravidade);
        }

    }
}
