using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Processo
    {
        public int ProcessoId { get; set; }
        public string relatoFiscalizacao { get; set; }
        public string dataRelato { get; set; }
        public string fiscalResponsavel { get; set; }
        public string numeroProcesso { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
