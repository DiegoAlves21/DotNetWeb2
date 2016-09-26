using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class AutoInfracaoViewModel
    {

        [Key]
        public int AutoInfracaoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Gravidade.")]
        public int gravidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Atenuante.")]
        public Boolean atenuante { get; set; }

        [Required(ErrorMessage = "Preencha o campo Agravante.")]
        public Boolean agravante { get; set; }

        public string multa { get; set; }

        [ForeignKey("processo")]
        public int ProcessoId { get; set; }
        public ProcessoViewModel processo { get; set; }

    }
}