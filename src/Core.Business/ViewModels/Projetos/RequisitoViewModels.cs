using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Business.ViewModels.Projetos
{
    public class RequisitoViewModels
    {
        [Key]
        public int CO_REQUISITO { get; set; }
        public int CO_PROJETO { get; set; }
        public string DESCRICAO { get; set; }
    }
}
