using System;

namespace Core.Business.Entities.Projetos
{
    public class Dashboard : Entity
    {
        public int CO_PROJETO { get; set; }
        public string NOME { get; set; }
        public string OBSERVACAO { get; set; }
        public DateTime? DT_INICIO { get; set; }
        public DateTime? DT_FIM { get; set; }
        public string GESTOR_DEMANDANTE { get; set; }
        public string NOME_DEMANDANTE { get; set; }
        public int? CO_COMPLEXIDADE { get; set; }
        public int? COMPLEXIDADE { get; set; }
        public int? CO_PRIORIDADE { get; set; }
        public int? PRIORIDADE { get; set; }
        public int? CO_TIPO { get; set; }
        public string DESCRICAO_TIPO { get; set; }
        public int? CO_STATUS { get; set; }
        public string DESCRICAO_STATUS { get; set; }
        public int? CO_CATEGORIA { get; set; }
        public string DESCRICAO_CATEGORIA { get; set; }
        public Decimal? PERCENTUAL { get; set; }
        public string CAIXA_POSTAL { get; set; }
        public string DESCRICAO { get; set; }
        public string NOME_GESTOR { get; set; }
        public string NOME_GERENTE { get; set; }
        public string NOME_PATROCINADOR { get; set; }
        public string MATRICULA_GERENTE { get; set; }
        public string MATRICULA_PATROCINADOR { get; set; }
        public int? CGC_UND { get; set; }
    }
}
