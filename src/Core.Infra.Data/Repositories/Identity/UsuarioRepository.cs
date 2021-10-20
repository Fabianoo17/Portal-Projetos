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
    public class UsuarioRepository : EFRepositoryBase<Usuario, DefaultDbContext>, IUsuarioRepository
    {
        public UsuarioRepository(DefaultDbContext defaultDbContext) : base(defaultDbContext)
        {
        }

        public async Task<IEnumerable<Usuario>> PesquisarUsuarios(string nomeOuMatricula)
        {
            nomeOuMatricula += "%";
            return await Entity
                .Where(x => (EF.Functions.Like(x.Matricula, nomeOuMatricula) || EF.Functions.Like(x.Nome, nomeOuMatricula)) && x.FLAG_ATIVO)
                .Take(10)
                .ToListAsync();
        }
    }
}