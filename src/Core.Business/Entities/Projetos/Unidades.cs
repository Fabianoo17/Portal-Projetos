using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Entities.Projetos
{
    public class Unidades : Entity
    {
        public int NU_UNIDADE { get; set; }
        public string SG_SIGLA { get; set; }
        public string NO_UNIDADE { get; set; }
        public string NO_RESPONSAVEL { get; set; }
        public string NU_MATRICULA { get; set; }
        public string NU_VINC_TI { get; set; }
        public string SG_VINC_TI { get; set; }
        public string NO_VINC_TI { get; set; }
        public string NU_VINC_ADM { get; set; }
        public string SG_VINC_ADM { get; set; }
        public string NO_VINC_ADM { get; set; }

        public ICollection<ParteInteressada> PartesInteressadas { get; set; }
    }
}




