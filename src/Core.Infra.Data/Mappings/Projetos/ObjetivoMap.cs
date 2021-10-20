using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class ObjetivoMap : IEntityTypeConfiguration<Objetivo>
    {
        public void Configure(EntityTypeBuilder<Objetivo> builder)
        {
            builder.ToTable("T004_OBJETIVOS");
            builder.HasKey(x => x.CO_OBJETIVO);
        }
    }
}