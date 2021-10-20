using System.Collections.Generic;

namespace Core.Business.Entities.Projetos
{
    public class StatusAtividadeMarcoEntrega : Entity
    {
        public int CO_STATUS_ATIVIDADE_MARCO_ENTREGA { get; set; }
        public string DESCRICAO { get; set; }
        public bool IS_ATIVO { get; set; }

        // NAVEGAÇAO

        public ICollection<AtividadesEntrega> AtividadesEntrega { get; set; }
    }
}