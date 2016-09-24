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
    public class ProcessoService : ServiceBase<Processo>, IProcessoService
    {
        private readonly IProcessoRepository _processoRepository;

        public ProcessoService(IProcessoRepository processoRepository) : base(processoRepository)
        {
            _processoRepository = processoRepository;
        }
        public IEnumerable<Processo> BuscarPorNumeroProcesso(string numero)
        {
            throw new NotImplementedException();
        }
    }
}
