using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class UnidadesMap : IEntityTypeConfiguration<Unidades>
    {
        public void Configure(EntityTypeBuilder<Unidades> builder)
        {
            builder.ToTable("VW001_UNIDADES");
            builder.HasKey(x => x.NU_UNIDADE);
        }
    }
}
