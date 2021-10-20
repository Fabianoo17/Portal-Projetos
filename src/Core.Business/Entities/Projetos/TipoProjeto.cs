using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.Entities.Projetos
{
    public class TipoProjeto : Entity
    {
        public int CO_TIPO { get; set; }
      
        public string DESCRICAO { get; set; }
        public bool IS_ATIVO { get; set; }


        // NAVEGAÇAO
        public ICollection<Projeto> Projetos { get; set; }
    }
}