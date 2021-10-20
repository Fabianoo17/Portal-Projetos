using Core.Business.Entities.Projetos;
using Core.Business.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels.Projetos
{
    public class ProjetoViewModel
    {
        public ProjetoViewModel()
        {
            Objetivos = new HashSet<ObjetivoViewModel>();
            Custos = new HashSet<CustoViewModel>();
            Justificativas = new HashSet<JustificativaViewModel>();
            Restricoes = new HashSet<RestricaoViewModel>();
            Riscos = new HashSet<RiscoViewModel>();
            Beneficios = new HashSet<BeneficioViewModel>();
            Premissas = new HashSet<PremissaViewModel>();
            MarcosEntregas = new HashSet<MarcosEntregaViewModel>();
            MarcosEntregasRelacionado = new HashSet<MarcosEntregaRelacionadoViewModel>();
            PartesInteressadas = new HashSet<ParteInteressadaViewModel>();
            EquipeApoio = new HashSet<ApoioViewModel>();
            Requisitos = new HashSet<RequisitoViewModels>();
            Escopos = new HashSet<EscopoViewModel>();
            NaoEscopos = new HashSet<NaoEscopoViewModel>();
            ProjetosFilho = new HashSet<ProjetoViewModel>();
        }

        [Key]
        public int CO_PROJETO { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome do Projeto")]
        public string NOME { get; set; }

        [Display(Name = "Resumo do Projeto")]
        [MaxLength(1000, ErrorMessage = "O campo deve ter no máximo 1000 caracteres")]
        public string DESCRICAO { get; set; }

        [Display(Name = "Data início")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DT_CADASTRO { get; set; }

        [Display(Name = "Data início")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DT_INICIO { get; set; }

        [Display(Name = "Data fim")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DT_FIM { get; set; }

        [Display(Name = "Matrícula")]
        public string GESTOR_DEMANDANTE { get; set; }

        [Display(Name = "Matrícula")]
        public string MATRICULA_PATROCINADOR { get; set; }

        [Display(Name = "Matrícula")]
        public string MATRICULA_GERENTE { get; set; }

        [Display(Name = "Cliente")]
        public int? CO_TIPO { get; set; }

        [Display(Name = "Categoria")]
        public int? CO_CATEGORIA { get; set; }

        [Display(Name = "Complexidade")]
        public int? CO_COMPLEXIDADE { get; set; }

        [Display(Name = "Prioridade")]
        public int? CO_PRIORIDADE { get; set; }

        [Display(Name = "Programa")]
        public int? CO_PROJETO_PAI { get; set; }

        [Display(Name = "Situação do Projeto")]
        public int? CO_STATUS { get; set; }

        [Display(Name = "% Desempenho")]
        public decimal? PERCENTUAL { get; set; }

        [Display(Name = "Link Documentação do Projeto")]
        public string LINK_DOCUMENTACAO { get; set; }

        [Display(Name = "Caixa postal")]
        public string CAIXA_POSTAL { get; set; }

        [Display(Name = "Observação")]
        public string OBSERVACAO { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DT_ALTERACAO { get; set; }
        public bool? IS_RASCUNHO { get; set; }

        public StatusProjetoViewModel StatusProjeto { get; set; }
        public TipoProjetoViewModel TipoProjeto { get; set; }
        public CategoriaViewModel CategoriaProjeto { get; set; }
        public ICollection<ObjetivoViewModel> Objetivos { get; set; }
        public ICollection<CustoViewModel> Custos { get; set; }
        public ICollection<JustificativaViewModel> Justificativas { get; set; }
        public ICollection<RestricaoViewModel> Restricoes { get; set; }
        public ICollection<RiscoViewModel> Riscos { get; set; }
        public ICollection<BeneficioViewModel> Beneficios { get; set; }
        public ICollection<PremissaViewModel> Premissas { get; set; }
        public ICollection<MarcosEntregaViewModel> MarcosEntregas { get; set; }
        public ICollection<MarcosEntregaRelacionadoViewModel> MarcosEntregasRelacionado { get; set; }
        public ICollection<ParteInteressadaViewModel> PartesInteressadas { get; set; }
        public ICollection<ApoioViewModel> EquipeApoio { get; set; }
        public ICollection<EscopoViewModel> Escopos { get; set; }
        public ICollection<NaoEscopoViewModel> NaoEscopos { get; set; }
        public ICollection<RequisitoViewModels> Requisitos { get; set; }
        public ICollection<ProjetoViewModel> ProjetosFilho { get; set; }

        public UsuarioViewModel Patrocinador { get; set; }
        public UsuarioViewModel Gerente { get; set; }

        public UsuarioViewModel Demandante { get; set; }
        public IEnumerable<TipoMarcosEntregasViewModels> TipoMarcosEntregas { get; set; }
        public IEnumerable<StatusAtividadeMarcoEntregaViewModel> StatusAtividadeMarcoEntrega { get; set; }
        public IEnumerable<MarcosEntregasAtivos> marcosEntregasAtivos { get; set; }
    }
}