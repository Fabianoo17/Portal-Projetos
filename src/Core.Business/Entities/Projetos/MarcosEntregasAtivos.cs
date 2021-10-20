using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Business.Entities.Projetos
{
    [Table("VW007_MARCOS_ENTREGAS_ATIVOS")]
    public class MarcosEntregasAtivos : Entity
    {
        [Key]
        public int CO_MARCOS_ENTREGA { get; set; }
        public int CO_PROJETO { get; set; }
        public string NOME_PROJETO { get; set; }
        public int? CGC_UND { get; set; }
        public string NO_UNIDADE { get; set; }
        public string SG_SIGLA { get; set; }
        public int? CO_TIPO_MARCOS_ENTREGA { get; set; }
        public string MATRICULA_RESPONSAVEL { get; set; }
        public string DESCRICAO { get; set; }
        public string NOTA { get; set; }
        public DateTime? DT_PREVISAO { get; set; }
        public int? STATUS { get; set; }
        public DateTime DT_CADASTRO { get; set; }
        public bool IS_ATIVO { get; set; }
    }
}
