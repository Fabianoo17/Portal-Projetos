using Core.Business.Entities.Identity;
using System;

namespace Core.Business.Entities.Projetos
{
    public class Apoio : Entity
    {
        public Apoio()
        {
            DT_CADASTRO = DateTime.Now;
        }

        public int CO_APOIO { get; set; }
        public int CO_PROJETO { get; set; }
        public string MATRICULA { get; set; }
        public DateTime DT_CADASTRO { get; set; }

        // NAVEGAÇÃO
        public Projeto Projeto { get; set; }
        public Usuario UserApoio { get; set; }
    }
}
