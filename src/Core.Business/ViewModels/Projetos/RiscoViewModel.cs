using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels.Projetos
{
    public class RiscoViewModel
    {
        [Key]
        public int CO_RISCO { get; set; }
        public int CO_PROJETO { get; set; }
        public string DESCRICAO { get; set; }
    }
}