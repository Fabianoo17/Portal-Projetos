using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class PrioridadeMap : IEntityTypeConfiguration<PrioridadeProjeto>
    {
        public void Configure(EntityTypeBuilder<PrioridadeProjeto> builder)
        {
            builder.ToTable("T016_PRIORIDADE");
            builder.HasKey("CO_PRIORIDADE");
        }
    }
}
