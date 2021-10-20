using Core.Business.Entities.Projetos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Repositories
{
    public interface IMarcosEntregaRepository : IRepositoryBaseReader<MarcosEntrega>, IRepositoryBaseWriter<MarcosEntrega>
    {
        Task<IEnumerable<MarcosEntregasAtivos>> ObterListaMarcosEntrega();
        Task<MarcosEntregaRelacionado> SalvarMarcoRelacionado(MarcosEntregaRelacionado model);
    }
}
