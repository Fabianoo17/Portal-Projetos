using AutoMapper;
using Core.Business.Entities.Identity;
using Core.Business.Entities.Projetos;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Identity;
using Core.Business.ViewModels.Projetos;

namespace Core.Business.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Identity
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<DadosAD, UsuarioViewModel>()
                .ForMember(dest => dest.Matricula, opt => opt.MapFrom(src => src.samAccountName.ToUpper()))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.name));

            CreateMap<Perfil, PerfilViewModel>().ReverseMap();
            CreateMap<UsuarioAcesso, UsuarioAcessoViewModel>().ReverseMap();
            CreateMap<UsuarioPerfil, UsuarioPerfilViewModel>().ReverseMap();

            // Projeto
            CreateMap<ProjetoViewModel, Projeto>().ReverseMap();
            CreateMap<StatusProjetoViewModel, StatusProjeto>().ReverseMap();
            CreateMap<TipoProjetoViewModel, TipoProjeto>().ReverseMap();
            CreateMap<BeneficioViewModel, Beneficio>().ReverseMap();
            CreateMap<CustoViewModel, Custo>().ReverseMap();
            CreateMap<JustificativaViewModel, Justificativa>().ReverseMap();
            CreateMap<MarcosEntregaViewModel, MarcosEntrega>().ReverseMap();
            CreateMap<ObjetivoViewModel, Objetivo>().ReverseMap();
            CreateMap<PremissaViewModel, Premissa>().ReverseMap();
            CreateMap<RestricaoViewModel, Restricao>().ReverseMap();
            CreateMap<RiscoViewModel, Risco>().ReverseMap();
            CreateMap<ApoioViewModel, Apoio>().ReverseMap();
            CreateMap<ParteInteressada, ParteInteressadaViewModel>().ReverseMap();
            CreateMap<UnidadeViewModel, Unidades>().ReverseMap();
            CreateMap<ComplexidadeProjetoViewModel, ComplexidadeProjeto>().ReverseMap();
            CreateMap<PrioridadeProjetoViewModel, PrioridadeProjeto>().ReverseMap();
            CreateMap<EscopoViewModel, Escopo>().ReverseMap();
            CreateMap<RequisitoViewModels, Requisito>().ReverseMap();
            CreateMap<NaoEscopoViewModel, NaoEscopo>().ReverseMap();
            CreateMap<CategoriaViewModel, Categoria>().ReverseMap();
            CreateMap<TipoMarcosEntregasViewModels, TipoMarcosEntregas>().ReverseMap();
            CreateMap<AtividadesEntregaViewModel, AtividadesEntrega>().ReverseMap();
            CreateMap<StatusAtividadeMarcoEntregaViewModel, StatusAtividadeMarcoEntrega>().ReverseMap();
            CreateMap<MarcosEntregaRelacionado, MarcosEntregaRelacionadoViewModel>().ReverseMap();
        }
    }
}