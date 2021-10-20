using System.Collections.Generic;

namespace Core.Business.Entities.Projetos
{
    public class StatusProjeto : Entity
    {
        public int CO_STATUS { get; set; }
        public string DESCRICAO { get; set; }
        public bool IS_ATIVO { get; set; }

        // NAVEGAÇAO
        public ICollection<Projeto> Projetos { get; set; }
        public ICollection<MarcosEntrega> Entregas { get; set; }
    }
}