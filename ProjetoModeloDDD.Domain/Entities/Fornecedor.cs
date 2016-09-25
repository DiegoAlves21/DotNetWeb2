using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string ReceitaBruta { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
