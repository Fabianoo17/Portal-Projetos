using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class AtividadesEntregaMap : IEntityTypeConfiguration<AtividadesEntrega>
    {
        public void Configure(EntityTypeBuilder<AtividadesEntrega> builder)
        {
            builder.ToTable("T022_ATIVIDADES_ENTREGA");
            builder.HasKey(x => x.CO_ATIVIDADES_ENTREGA);

            builder.HasOne(x => x.StatusAtividadeMarcosEntrega)
                .WithMany(x => x.AtividadesEntrega)
                .HasForeignKey(x => x.STATUS);

        }
    }
}
