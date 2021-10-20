using Core.Business.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Identity
{
    public class DadosADMap : IEntityTypeConfiguration<DadosAD>
    {
        public void Configure(EntityTypeBuilder<DadosAD> builder)
        {
            builder.ToTable("T000_DADOS_AD_LDAP");

            builder.HasKey(x => x.name);
        }
    }
}