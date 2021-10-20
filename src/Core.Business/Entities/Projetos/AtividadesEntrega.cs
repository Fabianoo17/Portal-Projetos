using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.Entities.Projetos
{
    public class AtividadesEntrega : Entity
    {

        [Key]
        public int CO_ATIVIDADES_ENTREGA { get; set; }
        public int CO_MARCOS_ENTREGA { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime? DT_INICIO_PREVISTO { get; set; }
        public DateTime? DT_FIM_PREVISTO { get; set; }
        public DateTime? DT_FIM_REAL { get; set; }
        public int? STATUS { get; set; }
        public string MAT_RESPONSAVEL { get; set; }
        public DateTime? DT_CRIACAO { get; set; }
        public string CRIADOR { get; set; }
        public int? CO_PROJETO_CRIADO{ get; set; }

        public MarcosEntrega MarcoEntrega { get; set; }
        public MarcosEntregaRelacionado MarcoEntregaRelacionado { get; set; }
        public StatusAtividadeMarcoEntrega StatusAtividadeMarcosEntrega { get; set; }

    }
}
