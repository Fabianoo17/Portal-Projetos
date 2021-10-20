using Core.Business.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra.Data.Mappings.Identity
{
    public class UsuarioVinculadoMap : IEntityTypeConfiguration<UsuarioVinculado>
    {
        public void Configure(EntityTypeBuilder<UsuarioVinculado> builder)
        {
            builder.ToTable("T000_USUARIO_VINCULADO");

            builder.HasKey(x => new { x.MATRICULA_GERENTE, x.MATRICULA_VINCULO });

            builder.HasOne(x => x.Vinculo)
                .WithMany(x => x.UsuariosVinculados)
                .HasForeignKey(x => x.MATRICULA_VINCULO);
        }
    }
}
