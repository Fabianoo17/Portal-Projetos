using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels.Projetos
{
    public class JustificativaViewModel 
    {
        [Key]
        public int CO_JUSTIFICATIVA { get; set; }
        public int CO_PROJETO { get; set; }
        public string DESCRICAO { get; set; }
    }
}