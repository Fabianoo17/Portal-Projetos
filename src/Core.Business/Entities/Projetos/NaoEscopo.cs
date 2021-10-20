using System;

namespace Core.Business.Entities.Projetos
{
    public class NaoEscopo : Entity
    {
        public NaoEscopo()
        {
            DT_CADASTRO = DateTime.Now;
        }

        public int CO_NAO_ESCOPO { get; set; }
        public int CO_PROJETO { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DT_CADASTRO { get; set; }

        // NAVEGAÇÃO
        public Projeto Projeto { get; set; }

    }
}
