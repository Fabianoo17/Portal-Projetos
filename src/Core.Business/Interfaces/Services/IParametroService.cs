using Core.Business.ViewModels;
using Core.Business.ViewModels.Projetos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Services
{
    public interface IParametroService
    {
        Task<ParametrosViewModel> ObterParametros();
        Task<IEnumerable<TipoMarcosEntregasViewModels>> ObterTipoMarcosEntregas();
        Task<IEnumerable<StatusAtividadeMarcoEntregaViewModel>> ObterStatusAtvidadeMarcosEntrega();

        Task AdicionarComplexidade(ComplexidadeProjetoViewModel model);
        Task AtualizarComplexidade(ComplexidadeProjetoViewModel model);

        Task AdicionaPrioridade(PrioridadeProjetoViewModel model);
        Task AtualizarPrioridade(PrioridadeProjetoViewModel model);

        Task AdicionarTipoProjeto(TipoProjetoViewModel model);
        Task AtualizarTipoProjeto(TipoProjetoViewModel model);

        Task AdcionarStatusProjeto(StatusProjetoViewModel model);
        Task AtualizarStatusProjeto(StatusProjetoViewModel model);

        Task AdicionarCategoria(CategoriaViewModel model);
        Task AtualizarCategoria(CategoriaViewModel model);

        Task AdicionarTipoMarcosEntregas(TipoMarcosEntregasViewModels model);
        Task AtualizarTipoMarcosEntregas(TipoMarcosEntregasViewModels model);

        Task AdicionarStatusAtividadeEntrega(StatusAtividadeMarcoEntregaViewModel model);
        Task AtualizarStatusAtividadeEntrega(StatusAtividadeMarcoEntregaViewModel model);

        Task<bool> ComplexidadeExiste(int Complexidade);
        Task<bool> PrioridadeExiste(int Prioridade);
        Task<bool> TipoProjetoExiste(string TipoProjeto);
        Task<bool> TipoMarcosEntregasExiste(string TipoProjeto);
        Task<bool> StatusProjetoExiste(string statusProjeto);
        Task<bool> CategoriaProjetoExiste(string categoria);
        Task<bool> StatusAtividadeEntregaExiste(string statusAtividade);
    }
}
