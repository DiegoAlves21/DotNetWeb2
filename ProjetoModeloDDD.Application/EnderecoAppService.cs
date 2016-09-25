using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class EnderecoAppService : AppServiceBase<Endereco>, IEnderecoAppService
    {
        private readonly IEnderecoService _EnderecoService;

        public EnderecoAppService(IEnderecoService EnderecoService) : base(EnderecoService)
        {
            _EnderecoService = EnderecoService;
        }
    }
}
