using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class StatusAtividadeMarcoEntregaMap : IEntityTypeConfiguration<StatusAtividadeMarcoEntrega>
    {
        public void Configure(EntityTypeBuilder<StatusAtividadeMarcoEntrega> builder)
        {
            builder.ToTable("T023_STATUS_ATIVIDADE_MARCO_ENTREGA");
            builder.HasKey(x => x.CO_STATUS_ATIVIDADE_MARCO_ENTREGA);
        }
    }
}