using AutoMapper;
using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Core.Business.EntitiesValidations.Projetos;
using Core.Business.Enums;
using Core.Business.Interfaces;
using Core.Business.Interfaces.Repositories;
using Core.Business.Interfaces.Services;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Identity;
using Core.Business.ViewModels.Projetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Business.Services
{
    public class ProjetoService : BaseService, IProjetoService
    {
        private readonly IMapper _mapper;
        private readonly IProjetoRepository _projetoRepository;
        private readonly ITipoProjetoRepository _tipoProjetoRepository;
        private readonly IStatusProjetoRepository _statusProjetoRepository;
        private readonly IUnidadesRepository _unidadesRepository;
        private readonly IComplexidadeRepository _complexidade;
        private readonly IPrioridadeRepository _prioridade;
        private readonly ICategoriaRepository _categoria;
        private readonly IResponsavelRepository _responsavel;
        private readonly IMarcosEntregaRepository _marcosEntregas;

        public ProjetoService(INotificador notificador,
                              IUser user,
                              IMapper mapper,
                              IProjetoRepository projetoRepository,
                              ITipoProjetoRepository tipoProjetoRepository,
                              IStatusProjetoRepository statusProjetoRepository,
                              IComplexidadeRepository complexidade,
                              IPrioridadeRepository prioridade,
                              IUnidadesRepository unidadesRepository,
                              ICategoriaRepository categoria,
                              IResponsavelRepository responsavel,
                              IMarcosEntregaRepository marcosEntrega) : base(notificador, user)
        {
            _mapper = mapper;
            _projetoRepository = projetoRepository;
            _tipoProjetoRepository = tipoProjetoRepository;
            _statusProjetoRepository = statusProjetoRepository;
            _unidadesRepository = unidadesRepository;
            _complexidade = complexidade;
            _prioridade = prioridade;
            _categoria = categoria;
            _responsavel = responsavel;
            _marcosEntregas = marcosEntrega;
        }

        public async Task<Projeto> CadastrarOuAtualizar(ProjetoViewModel viewModel)
        {
            bool isAdministrador = CustomAuthorize(new[] { EPerfil.Administrador });

            // Cadastrar ou Atualizar
            if (viewModel.CO_PROJETO == 0)
            {
                var model = _mapper.Map<Projeto>(viewModel);

                if (!ExecutarValidacao(new ProjetoValidation(), model))
                    return null;

                model.DT_CADASTRO = DateTime.Now;
                model.CGC_UND = Convert.ToInt16(UserCustom.UnidadeCodigo);
                model.MAT_CRIADOR = UserCustom.Matricula;
                model.DT_ALTERACAO = DateTime.Now;
                model.MAT_CRIADOR = UserCustom.Matricula;

                return await _projetoRepository.CreateAsync(model);
            }
            else
            {
                var modelDb = await _projetoRepository.ObterPorIdComIncludes(viewModel.CO_PROJETO);
                if (isAdministrador)
                {
                    modelDb.NOME = viewModel.NOME;
                    modelDb.GESTOR_DEMANDANTE = viewModel.GESTOR_DEMANDANTE?.ToUpper();
                    modelDb.MATRICULA_PATROCINADOR = viewModel.MATRICULA_PATROCINADOR?.ToUpper();
                    modelDb.MATRICULA_GERENTE = viewModel.MATRICULA_GERENTE?.ToUpper();
                    modelDb.CO_TIPO = viewModel.CO_TIPO;
                    modelDb.CO_PRIORIDADE = viewModel.CO_PRIORIDADE;
                    modelDb.CO_CATEGORIA = viewModel.CO_CATEGORIA;
                    modelDb.CO_PROJETO_PAI = viewModel.CO_PROJETO_PAI;
                    modelDb.CO_COMPLEXIDADE = viewModel.CO_COMPLEXIDADE;
                    modelDb.DT_INICIO = viewModel.DT_INICIO;
                    modelDb.DT_FIM = viewModel.DT_FIM;
                    modelDb.CO_STATUS = viewModel.CO_STATUS;
                }

                modelDb.DESCRICAO = viewModel.DESCRICAO;
                modelDb.IS_RASCUNHO = viewModel.IS_RASCUNHO;
                modelDb.PERCENTUAL = viewModel.PERCENTUAL;
                modelDb.CAIXA_POSTAL = viewModel.CAIXA_POSTAL;
                modelDb.OBSERVACAO = viewModel.OBSERVACAO;
                modelDb.LINK_DOCUMENTACAO = viewModel.LINK_DOCUMENTACAO;

                modelDb.DT_ALTERACAO = DateTime.Now;
                modelDb.MAT_ALTERACAO = UserCustom.Matricula;

                return await _projetoRepository.UpdateAsync(modelDb);
            }
        }

        public async Task<IEnumerable<ProjetoViewModel>> ObterTodos(DashboardViewModel filtro)
        {
            var model = await _projetoRepository.GetManyAsync(x => x.CGC_UND == Convert.ToInt32(UserCustom.UnidadeCodigo)
                  && (filtro.Tipo.Contains(x.CO_TIPO) || filtro.Tipo == null)
                  && (filtro.Categoria.Contains(x.CO_CATEGORIA) || filtro.Categoria == null)
                  && (filtro.Situacao.Contains(x.CO_STATUS) || filtro.Situacao == null)
                  && (filtro.Gerente.Contains(x.MATRICULA_GERENTE) || filtro.Gerente == null)
                  && (filtro.Demandante.Contains(x.GESTOR_DEMANDANTE) || filtro.Demandante == null)
                  , new List<Expression<Func<Projeto, object>>> {
                        i => i.StatusProjeto,
                        i => i.TipoProjeto,
                        i => i.Gerente
                    }
                  );

            return _mapper.Map<IEnumerable<ProjetoViewModel>>(model);
        }

        public async Task<IEnumerable<ProjetoViewModel>> ObterTodosProjetosComIncludes()
        {
            var model = await _projetoRepository.ObterTodosComIncludes();
            return _mapper.Map<IEnumerable<ProjetoViewModel>>(model.Where(x => x.CGC_UND == Convert.ToInt32(UserCustom.UnidadeCodigo)));
        }

        public async Task<IEnumerable<TipoProjetoViewModel>> ObterTipos()
        {
            var model = await _tipoProjetoRepository.GetManyAsync(x => x.IS_ATIVO);
            return _mapper.Map<IEnumerable<TipoProjetoViewModel>>(model.OrderBy(x => x.DESCRICAO));
        }

        public async Task<IEnumerable<TipoProjetoViewModel>> ObterTiposEdit(int coProjeto)
        {
            var projeto = await _projetoRepository.GetAsync(x => x.CO_PROJETO == coProjeto);
            var model = await _tipoProjetoRepository.GetManyAsync(x => x.IS_ATIVO || x.CO_TIPO == projeto.CO_TIPO);
            return _mapper.Map<IEnumerable<TipoProjetoViewModel>>(model.OrderBy(x => x.DESCRICAO));
        }

        public async Task<IEnumerable<StatusProjetoViewModel>> ObterStatus()
        {
            var model = await _statusProjetoRepository.GetManyAsync(x => x.IS_ATIVO);
            return _mapper.Map<IEnumerable<StatusProjetoViewModel>>(model.OrderBy(x => x.DESCRICAO));
        }

        public async Task<IEnumerable<StatusProjetoViewModel>> ObterStatusEdit(int coProjeto)
        {
            var projeto = await _projetoRepository.GetAsync(x => x.CO_PROJETO == coProjeto);
            var model = await _statusProjetoRepository.GetManyAsync(x => x.IS_ATIVO || x.CO_STATUS == projeto.CO_STATUS);
            return _mapper.Map<IEnumerable<StatusProjetoViewModel>>(model.OrderBy(x => x.DESCRICAO));
        }

        public async Task<IEnumerable<ComplexidadeProjetoViewModel>> ObterComplexidades()
        {
            var model = await _complexidade.GetManyAsync(x => x.IS_ATIVO);
            return _mapper.Map<IEnumerable<ComplexidadeProjetoViewModel>>(model);
        }

        public async Task<IEnumerable<ComplexidadeProjetoViewModel>> ObterComplexidadesEdit(int coProjeto)
        {
            var projeto = await _projetoRepository.GetAsync(x => x.CO_PROJETO == coProjeto);
            var model = await _complexidade.GetManyAsync(x => x.IS_ATIVO || x.CO_COMPLEXIDADE == projeto.CO_COMPLEXIDADE);
            return _mapper.Map<IEnumerable<ComplexidadeProjetoViewModel>>(model);
        }

        public async Task<IEnumerable<PrioridadeProjetoViewModel>> ObterPrioridades()
        {
            var model = await _prioridade.GetManyAsync(x => x.IS_ATIVO);
            return _mapper.Map<IEnumerable<PrioridadeProjetoViewModel>>(model);
        }

        public async Task<IEnumerable<PrioridadeProjetoViewModel>> ObterPrioridadesEdit(int coProjeto)
        {
            var projeto = await _projetoRepository.GetAsync(x => x.CO_PROJETO == coProjeto);
            var model = await _prioridade.GetManyAsync(x => x.IS_ATIVO || x.CO_PRIORIDADE == projeto.CO_PRIORIDADE);
            return _mapper.Map<IEnumerable<PrioridadeProjetoViewModel>>(model);
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            var model = await _categoria.GetManyAsync(x => x.IS_ATIVO);
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(model);
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterCategoriasEdit(int coProjeto)
        {
            var projeto = await _projetoRepository.GetAsync(x => x.CO_PROJETO == coProjeto);
            var model = await _categoria.GetManyAsync(x => x.IS_ATIVO || x.CO_CATEGORIA == projeto.CO_CATEGORIA);
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(model);
        }

        public async Task<IEnumerable<ProjetoViewModel>> ObterProjetos()
        {
            var model = await _projetoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjetoViewModel>>(model);
        }

        public async Task<IEnumerable<Responsavel>> Responsaveis(int co_projeto)
        {
            return await _responsavel.GetManyAsync(x => x.CO_PROJETO == co_projeto || co_projeto == 0);

        }

        public async Task<IEnumerable<ProjetoViewModel>> ObterProjetosEdit(int coProjeto)
        {
            var model = await _projetoRepository.GetManyAsync(x => x.CO_PROJETO != coProjeto);
            return _mapper.Map<IEnumerable<ProjetoViewModel>>(model);
        }

        public async Task<ProjetoViewModel> ObterPorId(int projetoId)
        {
            var model = await _projetoRepository.ObterPorIdComIncludes(projetoId);

            var viewModel = _mapper.Map<ProjetoViewModel>(model);

            if (!viewModel.Objetivos.Any())
                viewModel.Objetivos.Add(new ObjetivoViewModel());

            if (!viewModel.Custos.Any())
                viewModel.Custos.Add(new CustoViewModel());

            if (!viewModel.Justificativas.Any())
                viewModel.Justificativas.Add(new JustificativaViewModel());

            if (!viewModel.Restricoes.Any())
                viewModel.Restricoes.Add(new RestricaoViewModel());

            if (!viewModel.Riscos.Any())
                viewModel.Riscos.Add(new RiscoViewModel());

            if (!viewModel.Beneficios.Any())
                viewModel.Beneficios.Add(new BeneficioViewModel());

            if (!viewModel.Premissas.Any())
                viewModel.Premissas.Add(new PremissaViewModel());

            if (!viewModel.MarcosEntregas.Any())
            {
                viewModel.MarcosEntregas.Add(new MarcosEntregaViewModel
                {
                    AtividadesEntregas = new List<AtividadesEntregaViewModel> {
                       new AtividadesEntregaViewModel()
                    }
                });
            }
            else
            {
                foreach (var item in viewModel.MarcosEntregas)
                {
                    if (!item.AtividadesEntregas.Any())
                        item.AtividadesEntregas.Add(new AtividadesEntregaViewModel());
                }
            }

            //if (!viewModel.MarcosEntregasRelacionado.Any())
            //{
            //    viewModel.MarcosEntregasRelacionado.Add(new MarcosEntregaRelacionadoViewModel
            //    {
            //        AtividadesEntregas = new List<AtividadesEntregaViewModel> {
            //           new AtividadesEntregaViewModel()
            //        },
            //        MarcosEntrega = new MarcosEntregaViewModel()

            //    });
            //}
            //else
            //{
            foreach (var item in viewModel.MarcosEntregasRelacionado)
            {
                if (!item.AtividadesEntregas.Any())
                    item.AtividadesEntregas.Add(new AtividadesEntregaViewModel());
            }
            //}

            if (!viewModel.PartesInteressadas.Any())
                viewModel.PartesInteressadas.Add(new ParteInteressadaViewModel());

            if (!viewModel.EquipeApoio.Any())
                viewModel.EquipeApoio.Add(new ApoioViewModel());

            if (!viewModel.Escopos.Any())
                viewModel.Escopos.Add(new EscopoViewModel());

            if (!viewModel.NaoEscopos.Any())
                viewModel.NaoEscopos.Add(new NaoEscopoViewModel());

            if (!viewModel.Requisitos.Any())
                viewModel.Requisitos.Add(new RequisitoViewModels());

            return viewModel;
        }

        public async Task Excluir(int CO_PROJETO)
        {
            try
            {
                await _projetoRepository.RemoverProjetoESubItensAsync(CO_PROJETO);
            }
            catch (Exception ex)
            {
                Notificar(ex.Message);
            }
        }

        public async Task<IEnumerable<int>> ObterIdsProjetoPorMembro(string matricula)
        {
            return await _projetoRepository.ObterIdsProjetoPorMembro(matricula);
        }

        public Task<Unidades> ObterUnidadesPorId(int unidade)
        {
            return _unidadesRepository.GetAsync(x => x.NU_UNIDADE == unidade);
        }

        public async Task<IEnumerable<MarcosEntregasAtivos>> ObterListaMarcos()
        {
            return await _marcosEntregas.ObterListaMarcosEntrega();
        }

        public async Task CadastraMarcoRelacionado(MarcosEntregaRelacionadoViewModel model)
        {
            model.DT_CRIACAO = DateTime.Now;
            model.MAT_CRIADOR = UserCustom.Matricula;
            try
            {
                await _marcosEntregas.SalvarMarcoRelacionado(_mapper.Map<MarcosEntregaRelacionado>(model));

            }
            catch (Exception ex)
            {
                Notificar(ex.Message);
            }
        }

        public async Task<IEnumerable<object>> ObterItensProjeto(int cO_PROJETO, TipoItemProjeto tipoItemProjeto)
        {
            return await _projetoRepository.ObterItensProjeto(cO_PROJETO, tipoItemProjeto);
        }

        public async Task CadastrarOuAtualizarItens(ObjetivoViewModel viewModel)
        {
            if (viewModel.CO_OBJETIVO != 0)
            {
                
            }
        }
    }
}