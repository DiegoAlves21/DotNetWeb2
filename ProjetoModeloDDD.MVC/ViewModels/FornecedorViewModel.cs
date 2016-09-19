using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cnpj.")]
        [MaxLength(14, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(14, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Preencha o campo Marca.")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string RazaoSocial { get; set; }
    }
}