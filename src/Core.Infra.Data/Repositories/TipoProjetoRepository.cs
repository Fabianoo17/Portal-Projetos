using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Core.Infra.Data.Repositories
{
    public class TipoProjetoRepository : EFRepositoryBase<TipoProjeto, DefaultDbContext>, ITipoProjetoRepository
    {
        public TipoProjetoRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}