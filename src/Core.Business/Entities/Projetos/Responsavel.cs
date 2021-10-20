using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Business.Entities.Projetos
{
    public class Responsavel : Entity
    {
        [Key]
        public int ID { get; set; }
        public int CO_PROJETO { get; set; }
        public string MATRICULA_RESPONSAVEL { get; set; }
        public string NOME { get; set; }
    }
}
