using Core.Business.Entities.Projetos;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;

namespace Core.Infra.Data.Repositories
{
    public class UnidadesRepository : EFRepositoryBase<Unidades, DefaultDbContext>, IUnidadesRepository
    {
        public UnidadesRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
