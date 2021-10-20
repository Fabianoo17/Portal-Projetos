using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class ComplexidadeMap : IEntityTypeConfiguration<ComplexidadeProjeto>
    {
        public void Configure(EntityTypeBuilder<ComplexidadeProjeto> builder)
        {
            builder.ToTable("T015_COMPLEXIDADE");
            builder.HasKey(x => x.CO_COMPLEXIDADE);
        }

   
    }
}
