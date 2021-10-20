using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Entities.Projetos
{
    public class ComplexidadeProjeto : Entity
    {
        public int CO_COMPLEXIDADE { get; set; }
        public int COMPLEXIDADE { get; set; }
        public bool IS_ATIVO { get; set; }
    }
}
