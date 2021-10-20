using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class RestricaoMap : IEntityTypeConfiguration<Restricao>
    {
        public void Configure(EntityTypeBuilder<Restricao> builder)
        {
            builder.ToTable("T007_RESTRICOES");
            builder.HasKey(x => x.CO_RESTRICAO);
        }
    }
}