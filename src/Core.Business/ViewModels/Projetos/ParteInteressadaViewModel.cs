using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.ViewModels.Projetos
{
    public class ParteInteressadaViewModel
    {

        public int CO_PARTE { get; set; }
        public int CO_PROJETO { get; set; }
        public int CGC_UND { get; set; }

        public UnidadeViewModel Unidade { get; set; }
    }
}
