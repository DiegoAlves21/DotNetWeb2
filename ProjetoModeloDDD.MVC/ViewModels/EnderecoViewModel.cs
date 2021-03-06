﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cnpj.")]
        [MaxLength(100, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string logradouro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Numero.")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string numero { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string complemento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro.")]
        [MaxLength(100, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Municipio.")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(1, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string municipio { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cep.")]
        [MaxLength(9, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(9, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo Uf.")]
        public string uf { get; set; }
    }
}