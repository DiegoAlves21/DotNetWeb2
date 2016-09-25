using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class AutoInfracao
    {

        public int AutoInfracaoId { get; set; }
        public int gravidade { get; set; }
        public Boolean atenuante { get; set; }
        public Boolean agravante { get; set; }
        public string multa { get; set; }
        public Processo Processo { get; set; }

    }
}
