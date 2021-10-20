using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class EscopoMap : IEntityTypeConfiguration<Escopo>
    {
        public void Configure(EntityTypeBuilder<Escopo> builder)
        {
            builder.ToTable("T017_ESCOPO");
            builder.HasKey(x => x.CO_ESCOPO);
        }
    }
}
