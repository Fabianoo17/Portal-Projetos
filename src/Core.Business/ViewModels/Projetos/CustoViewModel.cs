using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels.Projetos
{
    public class CustoViewModel
    {
        [Key]
        public int CO_CUSTO { get; set; }
        public int CO_PROJETO { get; set; }
        public string DESCRICAO { get; set; }
        public decimal VALOR { get; set; }
    }
}