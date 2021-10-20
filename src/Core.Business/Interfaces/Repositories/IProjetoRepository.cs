using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Core.Business.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Repositories
{
    public interface IProjetoRepository : IRepositoryBaseReader<Projeto>, IRepositoryBaseWriter<Projeto>
    {
        Task AddSubItens<T>(IEnumerable<T> itens) where T : Entity;
        Task RemoverSubItens<T>(IEnumerable<T> itens) where T : Entity;
        Task RemoverProjetoESubItensAsync(int projetoId);
        bool PossuiAcessoAoProjeto(int projetoId, string matricula);
        Task<IEnumerable<int>> ObterIdsProjetoPorMembro(string matricula);
        Task<Projeto> ObterPorIdComIncludes(int projetoId);
        Task<IEnumerable<Projeto>> ObterTodosComIncludes();

        Task<IEnumerable<object>> ObterItensProjeto(int cO_PROJETO, TipoItemProjeto tipoItemProjeto);
    }
}