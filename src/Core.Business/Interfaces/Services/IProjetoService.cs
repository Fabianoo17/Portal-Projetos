using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Core.Business.Enums;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Projetos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Services
{
    public interface IProjetoService
    {
        Task<Projeto> CadastrarOuAtualizar(ProjetoViewModel viewModel);
        Task<IEnumerable<ProjetoViewModel>> ObterTodos(DashboardViewModel filtro);
        Task<IEnumerable<TipoProjetoViewModel>> ObterTipos();
        Task<IEnumerable<TipoProjetoViewModel>> ObterTiposEdit(int coProjeto);
        Task<IEnumerable<StatusProjetoViewModel>> ObterStatus();
        Task<IEnumerable<StatusProjetoViewModel>> ObterStatusEdit(int coProjeto);
        Task<ProjetoViewModel> ObterPorId(int projetoId);
        Task Excluir(int CO_PROJETO);
        Task<IEnumerable<int>> ObterIdsProjetoPorMembro(string matricula);
        Task<Unidades> ObterUnidadesPorId(int unidade);
        Task<IEnumerable<PrioridadeProjetoViewModel>> ObterPrioridades();
        Task<IEnumerable<PrioridadeProjetoViewModel>> ObterPrioridadesEdit(int coProjeto);
        Task<IEnumerable<ComplexidadeProjetoViewModel>> ObterComplexidades();
        Task<IEnumerable<ComplexidadeProjetoViewModel>> ObterComplexidadesEdit(int coProjeto);
        Task<IEnumerable<ProjetoViewModel>> ObterProjetos();
        Task<IEnumerable<ProjetoViewModel>> ObterProjetosEdit(int coProjeto);
        Task<IEnumerable<CategoriaViewModel>> ObterCategorias();
        Task<IEnumerable<CategoriaViewModel>> ObterCategoriasEdit(int coProjeto);
        Task<IEnumerable<ProjetoViewModel>> ObterTodosProjetosComIncludes();
        Task<IEnumerable<Responsavel>> Responsaveis(int co_projeto);
        Task<IEnumerable<MarcosEntregasAtivos>> ObterListaMarcos();
        Task CadastraMarcoRelacionado(MarcosEntregaRelacionadoViewModel model);

        Task<IEnumerable<object>> ObterItensProjeto(int cO_PROJETO, TipoItemProjeto tipoItemProjeto);
        Task CadastrarOuAtualizarItens(ObjetivoViewModel viewModel);
    }
}