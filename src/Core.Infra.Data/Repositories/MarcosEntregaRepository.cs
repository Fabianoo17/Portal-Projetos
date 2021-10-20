using Core.Business.Entities.Projetos;
using Core.Business.Interfaces.Repositories;
using Core.Business.ViewModels.Projetos;
using Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Infra.Data.Repositories
{
    public class MarcosEntregaRepository : EFRepositoryBase<MarcosEntrega, DefaultDbContext>, IMarcosEntregaRepository
    {
        public MarcosEntregaRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<MarcosEntregasAtivos>> ObterListaMarcosEntrega()
        {

            return await DbContext.MarcosEntregaAtivos.ToListAsync();
            

        }

        public async Task<MarcosEntregaRelacionado> SalvarMarcoRelacionado(MarcosEntregaRelacionado model)
        {
             DbContext.MarcosEntregaRelacionado.Add(model);
            await DbContext.SaveChangesAsync();
            return model;
        


        }
    }
}
