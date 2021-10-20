using Core.Business.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Identity
{
    public class UsuarioAcessoMap : IEntityTypeConfiguration<UsuarioAcesso>
    {
        public void Configure(EntityTypeBuilder<UsuarioAcesso> builder)
        {
            builder.ToTable("T000_USUARIO_ACESSO");

            builder.HasKey(x => x.MATRICULA);

            builder.Property(x => x.MATRICULA)
                .HasMaxLength(50);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.UsuariosAcesso)
                .HasForeignKey(x => x.MATRICULA);

            builder.HasMany(x => x.UsuariosPerfis)
                .WithOne(x => x.UsuarioAcesso)
                .HasForeignKey(x => x.MATRICULA);

            builder.HasMany(x => x.UsuariosVinculados)
                .WithOne(x => x.UsuarioAcesso)
                .HasForeignKey(x => x.MATRICULA_GERENTE);
        }
    }
}