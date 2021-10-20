using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Entities.Projetos
{
    public class ParteInteressada : Entity
    {
        public ParteInteressada()
        {
            DT_CADASTRO = DateTime.Now;
        }

        public int CO_PARTE { get; set; }
        public int CO_PROJETO { get; set; }
        public int CGC_UND { get; set; }
        public DateTime DT_CADASTRO { get; set; }

        //NAVEGAÇÃO

        public Projeto Projeto { get; set; }
        public Unidades Unidade { get; set; }
    }
}
