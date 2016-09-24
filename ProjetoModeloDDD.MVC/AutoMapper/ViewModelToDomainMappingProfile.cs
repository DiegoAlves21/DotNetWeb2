using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public override string ProfileName
        {
            get { return "DomainToViewModelMappingProfile"; }
        }

        protected override void Configure()
        {
            //Deprecated, será removido no 5.0
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<ProcessoViewModel, Processo>();
        }
    }
}