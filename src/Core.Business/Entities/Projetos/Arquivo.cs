using System;
using System.Collections.Generic;

namespace Core.Business.Entities.Projetos
{
    public class Arquivo : Entity
    {
        public Arquivo()
        {
            DT_CADASTRO = DateTime.Now;
        }

        public int CO_ARQUIVO { get; set; }
        public int CO_PROJETO { get; set; }
        public string NOME { get; set; }
        public string ENDERECO { get; set; }
        public DateTime DT_CADASTRO { get; set; }

        // NAVEGAÇÃO
        public Projeto Projeto { get; set; }
    }
}