using Core.Business.Entities.Projetos;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;

namespace Core.Infra.Data.Repositories
{
    public class TipoMarcosEntregasRepository : EFRepositoryBase<TipoMarcosEntregas, DefaultDbContext>, ITipoMarcosEntregasRepository
    {
        public TipoMarcosEntregasRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}