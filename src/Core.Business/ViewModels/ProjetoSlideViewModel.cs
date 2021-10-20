using Core.Business.ViewModels.Projetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.ViewModels
{
    public class ProjetoSlideViewModel
    {
        public ProjetoSlideViewModel()
        {
            ListaProjetos = new List<ProjetoViewModel>();

        }



        public IEnumerable<ProjetoViewModel> ListaProjetos { get; set; }

        public string Demandante { get; set; }
        public string Gerente { get; set; }
        public int? Tipo { get; set; }
        public int? Situacao { get; set; }
        public int? Categoria { get; set; }

    }
}
