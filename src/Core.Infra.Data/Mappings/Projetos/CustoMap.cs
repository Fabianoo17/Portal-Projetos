using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class CustoMap : IEntityTypeConfiguration<Custo>
    {
        public void Configure(EntityTypeBuilder<Custo> builder)
        {
            builder.ToTable("T005_CUSTOS");
            builder.HasKey(x => x.CO_CUSTO);
        }
    }
}