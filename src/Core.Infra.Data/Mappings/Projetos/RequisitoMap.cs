using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class RequisitoMap : IEntityTypeConfiguration<Requisito>
    {
        public void Configure(EntityTypeBuilder<Requisito> builder)
        {
            builder.ToTable("T019_REQUISITOS");
            builder.HasKey(x => x.CO_REQUISITO);

        }

    }
}
