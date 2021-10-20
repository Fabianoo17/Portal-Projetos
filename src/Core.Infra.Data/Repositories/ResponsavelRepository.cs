using Core.Business.Entities.Projetos;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;

namespace Core.Infra.Data.Repositories
{
    public class ResponsavelRepository : EFRepositoryBase<Responsavel, DefaultDbContext>, IResponsavelRepository
    {
        public ResponsavelRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}