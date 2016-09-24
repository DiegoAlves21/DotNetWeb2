﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class AutoInfracaoViewModel
    {

        [Key]
        public int AutoInfracaoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Gravidade.")]
        [MaxLength(100, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres.")]
        public int gravidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Atenuante.")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres.")]
        public Boolean atenuante { get; set; }

        [Required(ErrorMessage = "Preencha o campo Agravante.")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres.")]
        public Boolean agravante { get; set; }

        [Required(ErrorMessage = "Preencha o campo Multa.")]
        [MaxLength(100, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres.")]
        public decimal multa { get; set; }

        public virtual ProcessoViewModel processo { get; set; }

    }
}