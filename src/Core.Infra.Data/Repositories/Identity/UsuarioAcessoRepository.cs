using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Business.Entities.Identity;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Business.Interfaces.Repositories.Identity;
using System.Linq.Expressions;
using System;

namespace Core.Infra.Data.Repositories.Identity
{
    public class UsuarioAcessoRepository : EFRepositoryBase<UsuarioAcesso, DefaultDbContext>, IUsuarioAcessoRepository
    {
        public UsuarioAcessoRepository(DefaultDbContext defaultDbContext) : base(defaultDbContext)
        {
        }

        public async Task<IEnumerable<UsuarioAcesso>> ObterUsuariosAcesso()
        {
            return await Entity
                .Include(x => x.Usuario).OrderBy(x=>x.Usuario.Nome)
                .Include(x => x.UsuariosPerfis).ThenInclude(i => i.Perfil)
                .ToListAsync();
        }

        public async Task<IEnumerable<Perfil>> ObterPerfis()
        {
            return await DbContext.Set<Perfil>().ToListAsync();
        }

        public async Task<UsuarioAcesso> AtualizarUsuario(UsuarioAcesso entity)
        {
            var itemDb = await GetAsync(x => x.MATRICULA == entity.MATRICULA,
                new List<Expression<System.Func<UsuarioAcesso, object>>>{
                    i => i.UsuariosPerfis
                });

            itemDb.UsuariosPerfis.Clear();
            itemDb.UsuariosPerfis = entity.UsuariosPerfis;
            await DbContext.SaveChangesAsync();

            return itemDb;
        }

        public async Task ExcluirUsuario(string matricula)
        {
            var itemDb = await GetAsync(x => x.MATRICULA == matricula,
                new List<Expression<Func<UsuarioAcesso, object>>>{
                    i => i.UsuariosPerfis,
                    i=> i.UsuariosVinculados
                });

            itemDb.UsuariosPerfis.Clear();
            itemDb.UsuariosVinculados.Clear();
            DbContext.Set<UsuarioAcesso>().Remove(itemDb);
            await DbContext.SaveChangesAsync();

            return;
        }

        public async Task<UsuarioAcesso> ObterUsuarioAcessoComVinculos(string matricula)
        {
            return await Entity
                .Include(x => x.Usuario)
                .Include(x => x.UsuariosVinculados).ThenInclude(i => i.Vinculo)
                .FirstOrDefaultAsync(x => x.MATRICULA == matricula);
        }
    }
}