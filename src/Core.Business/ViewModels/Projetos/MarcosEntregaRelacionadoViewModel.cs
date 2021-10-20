using Core.Business.Entities.Identity;
using Core.Business.Entities.Projetos;
using Core.Business.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels.Projetos
{
    public class MarcosEntregaRelacionadoViewModel
    {
        public MarcosEntregaRelacionadoViewModel()
        {
            AtividadesEntregas = new HashSet<AtividadesEntregaViewModel>();
        }

        
        public int CO_PROJETO { get; set; }
       
        public int CO_MARCOS_ENTREGA { get; set; }
        public string NOTA { get; set; }
        public string MAT_RESPONSAVEL { get; set; }
        public DateTime DT_CRIACAO { get; set; }
        public string MAT_CRIADOR { get; set; }



        public MarcosEntregaViewModel MarcosEntrega { get; set; }
        public ProjetoViewModel Projeto { get; set; }
        public UsuarioViewModel Responsavel { get; set; }
        public ICollection<AtividadesEntregaViewModel> AtividadesEntregas { get; set; }
    }
}