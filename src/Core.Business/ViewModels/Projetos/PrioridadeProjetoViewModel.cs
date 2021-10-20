using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.ViewModels.Projetos
{
    public class PrioridadeProjetoViewModel
    {
        public PrioridadeProjetoViewModel()
        {
            IS_ATIVO = true;
        }
        public int CO_PRIORIDADE { get; set; }
        public int PRIORIDADE { get; set; }
        public bool IS_ATIVO { get; set; }
    }
}
