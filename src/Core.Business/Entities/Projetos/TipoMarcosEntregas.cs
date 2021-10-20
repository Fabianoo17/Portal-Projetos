using System.Collections.Generic;

namespace Core.Business.Entities.Projetos
{
    public class TipoMarcosEntregas : Entity
    {
        
        public int CO_TIPO_MARCOS_ENTREGA { get; set; }
        public string NOME { get; set; }
        public bool IS_ATIVO { get; set; }


        public ICollection<MarcosEntrega> Entregas { get; set; }
    }
}
