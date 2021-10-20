using Core.Business.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Repositories.Identity
{
    public interface IUsuarioRepository : IRepositoryBaseReader<Usuario>
    {
        Task<IEnumerable<Usuario>> PesquisarUsuarios(string nomeOuMatricula);
    }
}