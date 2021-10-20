using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.ViewModels.Projetos
{
    public class ComplexidadeProjetoViewModel
    {
        public ComplexidadeProjetoViewModel()
        {
            IS_ATIVO = true;
        }
        public int CO_COMPLEXIDADE { get; set; }
        public int COMPLEXIDADE { get; set; }
        public bool IS_ATIVO { get; set; }
    }
}
