using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Core.Infra.Data.Repositories
{
    public class StatusProjetoRepository : EFRepositoryBase<StatusProjeto, DefaultDbContext>, IStatusProjetoRepository
    {
        public StatusProjetoRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}