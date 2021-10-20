using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class MarcosEntregaMap : IEntityTypeConfiguration<MarcosEntrega>
    {
        public void Configure(EntityTypeBuilder<MarcosEntrega> builder)
        {
            builder.ToTable("T011_MARCOS_ENTREGAS");
            builder.HasKey(x => x.CO_MARCOS_ENTREGA);

            builder.HasOne(x => x.SituacaoEntrega)
                .WithMany(x => x.Entregas)
                .HasForeignKey(x => x.STATUS);

            builder.HasOne(x => x.Responsavel)
                .WithMany(x => x.Entregas)
                .HasForeignKey(x => x.MATRICULA_RESPONSAVEL);

            builder.HasOne(x => x.TipoEntrega)
                .WithMany(x => x.Entregas)
                .HasForeignKey(x => x.CO_TIPO_MARCOS_ENTREGA);

            builder.HasMany(x => x.AtividadesEntregas)
                .WithOne(x => x.MarcoEntrega)
                .HasForeignKey(x => x.CO_MARCOS_ENTREGA);

        }
    }
}