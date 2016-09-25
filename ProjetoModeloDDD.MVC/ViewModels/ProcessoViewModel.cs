using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProcessoViewModel
    {
        [Key]
        public int ProcessoId { get; set; }

        public string numeroProcesso { get; set; }

        [Required(ErrorMessage = "Preencha o campo Relato Fiscalização.")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string relatoFiscalizacao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data do Relato.")]
        public string dataRelato { get; set; }

        [Required(ErrorMessage = "Preencha o campo Fiscal Responsável.")]
        public string fiscalResponsavel { get; set; }

        public virtual FornecedorViewModel Fornecedor { get; set; }
    }
}