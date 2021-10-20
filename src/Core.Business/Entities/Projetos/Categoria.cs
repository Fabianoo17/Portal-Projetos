using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Entities.Projetos
{
    public class Categoria : Entity
    {
        public int CO_CATEGORIA { get; set; }
        public string DESCRICAO { get; set; }
        public bool IS_ATIVO { get; set; }

        public ICollection<Projeto> Projetos { get; set; }
    }
}
