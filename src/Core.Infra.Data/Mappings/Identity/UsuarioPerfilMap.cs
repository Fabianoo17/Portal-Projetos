using Core.Business.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Identity
{
    public class UsuarioPerfilMap : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.ToTable("T000_USUARIO_PERFIL");

            builder.HasKey(x => new { x.MATRICULA, x.PERFIL_ID });

            builder.HasOne(x => x.UsuarioAcesso)
                .WithMany(x => x.UsuariosPerfis)
                .HasForeignKey(x => x.MATRICULA);

            builder.HasOne(x => x.Perfil)
                .WithMany(x => x.UsuarioPerfis)
                .HasForeignKey(x => x.PERFIL_ID);
        }
    }
}