using System;
using System.Collections.Generic;

namespace Core.Business.Entities.Projetos
{
    public class Custo : Entity
    {
        public Custo()
        {
            DT_CADASTRO = DateTime.Now;
        }

        public int CO_CUSTO { get; set; }
        public int CO_PROJETO { get; set; }
        public string DESCRICAO { get; set; }
        public decimal VALOR { get; set; }
        public DateTime DT_CADASTRO { get; set; }

        // NAVEGAÇÃO
        public Projeto Projeto { get; set; }
    }
}