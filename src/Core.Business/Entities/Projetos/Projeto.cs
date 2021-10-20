using Core.Business.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Core.Business.Entities.Projetos
{
    public class Projeto : Entity
    {
        public Projeto()
        {
            DT_CADASTRO = DateTime.Now;
            Objetivos = new HashSet<Objetivo>();
            Custos = new HashSet<Custo>();
            Justificativas = new HashSet<Justificativa>();
            Restricoes = new HashSet<Restricao>();
            Riscos = new HashSet<Risco>();
            Beneficios = new HashSet<Beneficio>();
            Premissas = new HashSet<Premissa>();
            MarcosEntregas = new HashSet<MarcosEntrega>();
            MarcosEntregasRelacionado = new HashSet<MarcosEntregaRelacionado>();
            Arquivos = new HashSet<Arquivo>();
            PartesInteressadas = new HashSet<ParteInteressada>();
            EquipeApoio = new HashSet<Apoio>();
            Requisitos = new HashSet<Requisito>();
            Escopos = new HashSet<Escopo>();
            NaoEscopos = new HashSet<NaoEscopo>();
            ProjetosFilho = new HashSet<Projeto>();
        }

        public int CO_PROJETO { get; set; }
        public string NOME { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime? DT_INICIO { get; set; }
        public DateTime? DT_FIM { get; set; }
        public string GESTOR_DEMANDANTE { get; set; }
        public string MATRICULA_PATROCINADOR { get; set; }
        public string MATRICULA_GERENTE { get; set; }
        public int? CO_TIPO { get; set; }
        public int? CO_COMPLEXIDADE { get; set; }
        public int? CO_CATEGORIA { get; set; }
        public int? CO_PRIORIDADE { get; set; }
        public int? CO_STATUS { get; set; }
        public decimal? PERCENTUAL { get; set; }
        public string LINK_DOCUMENTACAO { get; set; }
        public string CAIXA_POSTAL { get; set; }
        public string OBSERVACAO { get; set; }
        public int? CO_PROJETO_PAI { get; set; }
        public DateTime? DT_CADASTRO { get; set; }
        public int? CGC_UND { get; set; }
        public string MAT_CRIADOR { get; set; }
        public DateTime? DT_ALTERACAO { get; set; }
        public string MAT_ALTERACAO { get; set; }
        public bool? IS_RASCUNHO { get; set; }
        // Navegação
        public StatusProjeto StatusProjeto { get; set; }
        public TipoProjeto TipoProjeto { get; set; }
        public Categoria CategoriaProjeto { get; set; }
        public ICollection<Objetivo> Objetivos { get; set; }
        public ICollection<Custo> Custos { get; set; }
        public ICollection<Justificativa> Justificativas { get; set; }
        public ICollection<Restricao> Restricoes { get; set; }
        public ICollection<Risco> Riscos { get; set; }
        public ICollection<Beneficio> Beneficios { get; set; }
        public ICollection<Premissa> Premissas { get; set; }
        public ICollection<MarcosEntrega> MarcosEntregas { get; set; }
        public ICollection<MarcosEntregaRelacionado> MarcosEntregasRelacionado { get; set; }
        public ICollection<Arquivo> Arquivos { get; set; }
        public ICollection<ParteInteressada> PartesInteressadas { get; set; }
        public ICollection<Apoio> EquipeApoio { get; set; }
        public ICollection<Requisito> Requisitos { get; set; }
        public ICollection<Escopo> Escopos { get; set; }
        public ICollection<NaoEscopo> NaoEscopos { get; set; }

        public ICollection<Projeto> ProjetosFilho { get; set; }
        public Projeto ProjetoPai { get; set; }
        public Usuario Patrocinador { get; set; }
        public Usuario Gerente { get; set; }

        public Usuario Demandante { get; set; }
    }
}