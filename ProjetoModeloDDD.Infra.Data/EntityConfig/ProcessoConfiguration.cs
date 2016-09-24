using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ProcessoConfiguration : EntityTypeConfiguration<Processo>
    {
        public ProcessoConfiguration()
        {
            HasKey(p => p.ProcessoId);

            Property(p => p.numeroProcesso).IsRequired().HasMaxLength(28);

            //Property(p => p.Fornecedor.Cnpj).IsRequired().HasMaxLength(14);

            //Property(p => p.Fornecedor.RazaoSocial).IsRequired().HasMaxLength(200);

            Property(p => p.relatoFiscalizacao).IsRequired();

            Property(p => p.dataRelato).IsRequired();

            Property(p => p.fiscalResponsavel).IsRequired();

            HasRequired(p => p.Fornecedor);
        }
    }
}
