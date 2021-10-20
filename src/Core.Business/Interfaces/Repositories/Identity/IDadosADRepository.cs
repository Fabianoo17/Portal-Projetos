using Core.Business.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Repositories.Identity
{
    public interface IDadosADRepository : IRepositoryBaseReader<DadosAD>
    {
        Task<IEnumerable<DadosAD>> PesquisarUsuarios(string nomeOuMatricula);
    }
}