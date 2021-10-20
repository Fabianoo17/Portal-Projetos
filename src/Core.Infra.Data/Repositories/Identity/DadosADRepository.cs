using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Business.Entities.Identity;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Business.Interfaces.Repositories.Identity;

namespace Core.Infra.Data.Repositories.Identity
{
    public class DadosADRepository : EFRepositoryBase<DadosAD, CPTDB001DbContext>, IDadosADRepository
    {
        public DadosADRepository(CPTDB001DbContext defaultDbContext) : base(defaultDbContext)
        {
        }

        public async Task<IEnumerable<DadosAD>> PesquisarUsuarios(string nomeOuMatricula)
        {
            nomeOuMatricula += "%";
            return await Entity
                .Where(x => EF.Functions.Like(x.name, nomeOuMatricula))
                .Take(10)
                .ToListAsync();
        }
    }
}