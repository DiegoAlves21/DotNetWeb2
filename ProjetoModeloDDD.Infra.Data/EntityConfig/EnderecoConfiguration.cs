using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            Property(p => p.logradouro).IsRequired().HasMaxLength(100);

            Property(p => p.numero).IsRequired().HasMaxLength(50);

            Property(p => p.complemento);

            Property(p => p.bairro).IsRequired().HasMaxLength(100);

            Property(p => p.municipio).IsRequired().HasMaxLength(200);

            Property(p => p.cep).IsRequired().HasMaxLength(8);

            Property(p => p.uf).IsRequired().HasMaxLength(2);
        }
        
    }
}
