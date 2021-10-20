using Core.Business.Entities.Projetos;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Repositories
{
    public class CategoriaRepository : EFRepositoryBase<Categoria, DefaultDbContext>, ICategoriaRepository
    {
        public CategoriaRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
