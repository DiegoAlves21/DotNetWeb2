using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application
{
    public class AutoInfracaoAppService : AppServiceBase<AutoInfracao>, IAutoInfracaoAppService
    {

        private readonly IAutoInfracaoService _autoInfracaoService;

        public AutoInfracaoAppService(IAutoInfracaoService AutoInfracaoService) : base(AutoInfracaoService)
        {
            _autoInfracaoService = AutoInfracaoService;
        }

        public IEnumerable<AutoInfracao> BuscarPorGravidade(int gravidade)
        {
            return _autoInfracaoService.BuscarPorGravidade(gravidade);
        }

    }
}
