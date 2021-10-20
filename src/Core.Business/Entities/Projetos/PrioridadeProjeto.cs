using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Entities.Projetos
{
    public class PrioridadeProjeto : Entity
    {
        public int CO_PRIORIDADE { get; set; }
        public int PRIORIDADE { get; set; }
        public bool IS_ATIVO { get; set; }
    }
}
