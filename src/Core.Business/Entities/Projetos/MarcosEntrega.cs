using Core.Business.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.Projetos
{
    public class MarcosEntrega : Entity
    {
        public MarcosEntrega()
        {
            DT_CADASTRO = DateTime.Now;
            CO_TIPO_MARCOS_ENTREGA = 1;
            AtividadesEntregas = new HashSet<AtividadesEntrega>();
        }

        public int CO_MARCOS_ENTREGA { get; set; }
        public int CO_PROJETO { get; set; }
        public int? CO_TIPO_MARCOS_ENTREGA { get; set; }
        public string MATRICULA_RESPONSAVEL { get; set; }
        public string DESCRICAO { get; set; }
        public string NOTA { get; set; }
        public DateTime? DT_PREVISAO { get; set; }
        public int? STATUS { get; set; }
        public DateTime DT_CADASTRO { get; set; }

        // NAVEGAÇÃO
        public Projeto Projeto { get; set; }
        public StatusProjeto SituacaoEntrega {get; set;}
        public Usuario Responsavel { get; set; }
        public TipoMarcosEntregas TipoEntrega { get; set; }
        public ICollection<MarcosEntregaRelacionado> MarcosEntregaRelacionado { get; set; }

        public ICollection<AtividadesEntrega> AtividadesEntregas { get; set; }
    }
}