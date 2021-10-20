using Core.Business.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Identity
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("T000_USUARIOS");

            builder.HasKey(x => x.Matricula);

            builder.Property(x => x.Matricula)
                .HasColumnName("MATRICULA");

            builder.Property(x => x.Nome)
                .HasColumnName("NOME");

            builder.Property(x => x.CodigoUnidade)
                .HasColumnName("NU_UNID_ADM");

            builder.Property(x => x.NomeUnidade)
                .HasColumnName("NO_UNID_ADM");

            builder.Property(x => x.SiglaUnidade)
                .HasColumnName("SG_UNID_ADM");

            builder.Property(x => x.Funcao)
                .HasColumnName("NO_FUNCAO");
        }
    }
}