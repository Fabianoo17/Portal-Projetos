using Core.Business.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.ViewModels.Projetos
{
    public class ApoioViewModel
    {
 
        public int CO_APOIO { get; set; }
        public int CO_PROJETO { get; set; }
        public string MATRICULA { get; set; }

        public UsuarioViewModel UserApoio { get; set; }
    }
}
