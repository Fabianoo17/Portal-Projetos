using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class TipoMarcosEntregaMap : IEntityTypeConfiguration<TipoMarcosEntregas>
    {
        public void Configure(EntityTypeBuilder<TipoMarcosEntregas> builder)
        {
            builder.ToTable("T021_TIPO_MARCOS_ENTREGA");
            builder.HasKey(x => x.CO_TIPO_MARCOS_ENTREGA);
        }
    }
}
