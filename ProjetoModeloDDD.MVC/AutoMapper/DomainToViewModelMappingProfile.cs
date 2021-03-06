﻿using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public override string ProfileName
        {
            get{ return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            //Deprecated, será removido no 5.0
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Processo, ProcessoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<AutoInfracao, AutoInfracaoViewModel>();
        }
    }
}