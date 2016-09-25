using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cnpj.")]
        [MaxLength(18, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(18, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razao Social.")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string RazaoSocial { get; set; }

        [MaxLength(11, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(11, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string InscricaoMunicipal { get; set; }

        public string ReceitaBruta { get; set; }

        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public virtual EnderecoViewModel Endereco { get; set; }
}
}