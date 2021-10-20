using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Entities.Projetos
{
    public class Escopo : Entity
    {
        public Escopo()
        {
            DT_CADASTRO = DateTime.Now;    
        }
        public int CO_ESCOPO { get; set; }
        public int CO_PROJETO { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DT_CADASTRO { get; set; }

        // NAVEGAÇÃO
        public Projeto Projeto { get; set; }

    }
}
