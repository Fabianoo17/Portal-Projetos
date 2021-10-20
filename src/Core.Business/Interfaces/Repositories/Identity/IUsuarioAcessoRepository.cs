using Core.Business.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Repositories.Identity
{
    public interface IUsuarioAcessoRepository : IRepositoryBaseReader<UsuarioAcesso>, IRepositoryBaseWriter<UsuarioAcesso>
    {
        Task<IEnumerable<UsuarioAcesso>> ObterUsuariosAcesso();
        Task<IEnumerable<Perfil>> ObterPerfis();
        Task<UsuarioAcesso> AtualizarUsuario(UsuarioAcesso entity);
        Task ExcluirUsuario(string matricula);
        Task<UsuarioAcesso> ObterUsuarioAcessoComVinculos(string matricula);
    }
}