using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class StatusProjetoMap : IEntityTypeConfiguration<StatusProjeto>
    {
        public void Configure(EntityTypeBuilder<StatusProjeto> builder)
        {
            builder.ToTable("T002_STATUS_PROJETO");
            builder.HasKey(x => x.CO_STATUS);
        }
    }
}