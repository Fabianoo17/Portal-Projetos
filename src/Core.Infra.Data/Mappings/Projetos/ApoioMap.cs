using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class ApoioMap : IEntityTypeConfiguration<Apoio>
    {
        public void Configure(EntityTypeBuilder<Apoio> builder)
        {
            builder.ToTable("T014_APOIO");
            builder.HasKey(x => x.CO_APOIO);

            builder.HasOne(x => x.UserApoio)
                .WithMany(x => x.EquipeApoio)
                .HasForeignKey(x => x.MATRICULA);
        }
    }
}
