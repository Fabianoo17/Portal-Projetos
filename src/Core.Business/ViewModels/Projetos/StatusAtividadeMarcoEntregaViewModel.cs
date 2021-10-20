using System.Collections.Generic;

namespace Core.Business.ViewModels.Projetos
{
    public class StatusAtividadeMarcoEntregaViewModel 
    {
        public StatusAtividadeMarcoEntregaViewModel()
        {
            IS_ATIVO = true;
        }
        public int CO_STATUS_ATIVIDADE_MARCO_ENTREGA { get; set; }
        public string DESCRICAO { get; set; }
        public bool IS_ATIVO { get; set; }

        // NAVEGAÇAO

        public ICollection<AtividadesEntregaViewModel> AtividadesEntrega { get; set; }
    }
}