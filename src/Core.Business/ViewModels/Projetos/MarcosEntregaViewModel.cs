using Core.Business.Entities.Projetos;
using Core.Business.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels.Projetos
{
    public class MarcosEntregaViewModel 
    {
        public MarcosEntregaViewModel()
        {
            AtividadesEntregas = new HashSet<AtividadesEntregaViewModel>();
        }

        [Key]
        public int CO_MARCOS_ENTREGA { get; set; }
        public int CO_PROJETO { get; set; }
        public int? CO_TIPO_MARCOS_ENTREGA { get; set; }
        public string MATRICULA_RESPONSAVEL { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DT_PREVISAO { get; set; }
        public int? STATUS { get; set; }
        [MaxLength(2000, ErrorMessage = "O campo deve ter no máximo 2000 caracteres")]
        public string DESCRICAO { get; set; }
        public string NOTA { get; set; }

        public StatusProjetoViewModel SituacaoEntrega { get; set; }
        public UsuarioViewModel Responsavel { get; set; }
        public TipoMarcosEntregasViewModels TipoEntrega { get; set; }
        public ICollection<AtividadesEntregaViewModel> AtividadesEntregas { get; set; }
    }
}