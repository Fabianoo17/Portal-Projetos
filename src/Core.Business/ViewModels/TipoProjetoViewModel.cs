using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels
{
    public class TipoProjetoViewModel
    {
        public TipoProjetoViewModel()
        {
            IS_ATIVO = true;
        }
        public int CO_TIPO { get; set; }
        [Display(Name = "Clientes")]
        public string DESCRICAO { get; set; }
        public bool IS_ATIVO { get; set; }
    }
}