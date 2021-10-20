using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class JustificativaMap : IEntityTypeConfiguration<Justificativa>
    {
        public void Configure(EntityTypeBuilder<Justificativa> builder)
        {
            builder.ToTable("T006_JUSTIFICATIVAS");
            builder.HasKey(x => x.CO_JUSTIFICATIVA);
        }
    }
}