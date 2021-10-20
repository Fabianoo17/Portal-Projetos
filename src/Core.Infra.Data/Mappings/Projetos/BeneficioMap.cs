using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class BeneficioMap : IEntityTypeConfiguration<Beneficio>
    {
        public void Configure(EntityTypeBuilder<Beneficio> builder)
        {
            builder.ToTable("T009_BENEFICIOS");
            builder.HasKey(x => x.CO_BENEFICIO);
        }
    }
}