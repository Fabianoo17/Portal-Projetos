using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class ParteInteressadaMap : IEntityTypeConfiguration<ParteInteressada>
    {
        public void Configure(EntityTypeBuilder<ParteInteressada> builder)
        {
            builder.ToTable("T013_PARTES_INTERESSADAS");
            builder.HasKey(x => x.CO_PARTE);

            builder.HasOne(x => x.Unidade)
                .WithMany(x => x.PartesInteressadas)
                .HasForeignKey(x => x.CGC_UND);
        }
    }
}
