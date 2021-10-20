using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class NaoEscopoMap : IEntityTypeConfiguration<NaoEscopo>
    {
        public void Configure(EntityTypeBuilder<NaoEscopo> builder)
        {
            builder.ToTable("T018_NAO_ESCOPO");
            builder.HasKey(x => x.CO_NAO_ESCOPO);
        }
    }
}
