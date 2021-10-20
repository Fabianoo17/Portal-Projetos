using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class TipoProjetoMap : IEntityTypeConfiguration<TipoProjeto>
    {
        public void Configure(EntityTypeBuilder<TipoProjeto> builder)
        {
            builder.ToTable("T001_TIPO_PROJETO");
            builder.HasKey(x => x.CO_TIPO);
        }
    }
}