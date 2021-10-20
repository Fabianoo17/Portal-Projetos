using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class MarcosEntregaRelacionadoMap : IEntityTypeConfiguration<MarcosEntregaRelacionado>
    {
        public void Configure(EntityTypeBuilder<MarcosEntregaRelacionado> builder)
        {
            builder.ToTable("T025_MARCOS_ENTREGA_PROJETO_RELACIONADO");
            builder.HasKey(x => new {x.CO_PROJETO , x.CO_MARCOS_ENTREGA });

            builder.HasOne(x => x.MarcosEntrega)
                .WithMany(x => x.MarcosEntregaRelacionado)
                .HasForeignKey(x => x.CO_MARCOS_ENTREGA);

            //builder.HasOne(x => x.SituacaoEntrega)
            //    .WithMany(x => x.Entregas)
            //    .HasForeignKey(x => x.STATUS);

            builder.HasOne(x => x.Responsavel)
                .WithMany(x => x.EntregasRelacionadas)
                .HasForeignKey(x => x.MAT_RESPONSAVEL);

            //builder.HasOne(x => x.TipoEntrega)
            //    .WithMany(x => x.Entregas)
            //    .HasForeignKey(x => x.CO_TIPO_MARCOS_ENTREGA);

            builder.HasMany(x => x.AtividadesEntregas)
               
                .WithOne(x => x.MarcoEntregaRelacionado)
                .HasForeignKey(x => x.CO_MARCOS_ENTREGA)
                .HasPrincipalKey(x=>x.CO_MARCOS_ENTREGA);

        }
    }
}