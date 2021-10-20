using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class PremissaMap : IEntityTypeConfiguration<Premissa>
    {
        public void Configure(EntityTypeBuilder<Premissa> builder)
        {
            builder.ToTable("T010_PREMISSAS");
            builder.HasKey(x => x.CO_PREMISSA);
        }
    }
}