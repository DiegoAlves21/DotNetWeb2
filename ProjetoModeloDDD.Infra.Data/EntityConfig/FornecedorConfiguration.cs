using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    class FornecedorConfiguration : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfiguration()
        {
            HasKey(p => p.FornecedorId);

            Property(p => p.Cnpj).IsRequired().HasMaxLength(14);

            Property(p => p.RazaoSocial).IsRequired().HasMaxLength(200);

            Property(p => p.InscricaoMunicipal).IsRequired().HasMaxLength(8);

            Property(p => p.ReceitaBruta).IsRequired();

            HasOptional(p => p.Endereco);

            HasOptional(p => p.Produto);
        }
    }
}
