using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class AutoInfracaoConfiguration : EntityTypeConfiguration<AutoInfracao>
    {

        public AutoInfracaoConfiguration()
        {
            Property(p => p.gravidade).IsRequired();

            Property(p => p.atenuante).IsRequired();

            Property(p => p.multa).IsRequired();

            Property(p => p.agravante).IsRequired();

            HasRequired(p => p.Processo);
        }
    }
}
