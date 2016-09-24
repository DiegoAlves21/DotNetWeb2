using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class ProcessoAppService : AppServiceBase<Processo>, IProcessoAppService
    {
        private readonly IProcessoService _processoService;

        public ProcessoAppService(IProcessoService processoService) : base(processoService)
        {
            _processoService = processoService;
        }

        public IEnumerable<Processo> BuscarPorNumeroProcesso(string numero)
        {
            throw new NotImplementedException();
        }
    }
}
