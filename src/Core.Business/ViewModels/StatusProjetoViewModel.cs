using System.Collections.Generic;

namespace Core.Business.ViewModels
{
    public class StatusProjetoViewModel
    {
        public StatusProjetoViewModel()
        {
            IS_ATIVO = true;
        }
        public int CO_STATUS { get; set; }
        public string DESCRICAO { get; set; }
        public bool IS_ATIVO { get; set; }
    }
}