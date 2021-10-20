using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class RiscoMap : IEntityTypeConfiguration<Risco>
    {
        public void Configure(EntityTypeBuilder<Risco> builder)
        {
            builder.ToTable("T008_RISCOS");
            builder.HasKey(x => x.CO_RISCO);
        }
    }
}