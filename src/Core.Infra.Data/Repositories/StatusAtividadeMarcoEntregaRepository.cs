using Core.Business.Entities.Projetos;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;

namespace Core.Infra.Data.Repositories
{
    public class StatusAtividadeMarcoEntregaRepository : EFRepositoryBase<StatusAtividadeMarcoEntrega, DefaultDbContext>, IStatusAtividadeMarcoEntregaRepository
    {
        public StatusAtividadeMarcoEntregaRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}