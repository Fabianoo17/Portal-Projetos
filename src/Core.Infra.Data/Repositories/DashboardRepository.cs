using Core.Business.Entities.Projetos;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;

namespace Core.Infra.Data.Repositories
{
    public class DashboardRepository : EFRepositoryBase<Dashboard, DefaultDbContext>, IDashboardRepository
    {
        public DashboardRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
