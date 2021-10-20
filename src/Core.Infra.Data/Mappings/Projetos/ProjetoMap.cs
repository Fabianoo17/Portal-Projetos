using Core.Business.Entities.Projetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infra.Data.Mappings.Projetos
{
    public class ProjetoMap : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("T003_PROJETOS");

            builder.HasKey(x => x.CO_PROJETO);

            // 1 : 1 => Projeto : Status
            builder.HasOne(x => x.StatusProjeto)
                .WithMany(x => x.Projetos)
                .HasForeignKey(x => x.CO_STATUS);

            // 1 : 1 => Projeto : Status
            builder.HasOne(x => x.CategoriaProjeto)
                .WithMany(x => x.Projetos)
                .HasForeignKey(x => x.CO_CATEGORIA);

            // 1 : 1 => Projeto : Tipo
            builder.HasOne(x => x.TipoProjeto)
                .WithMany(x => x.Projetos)
                .HasForeignKey(x => x.CO_TIPO);

            // 1 : N => Projeto : Objetivos
            builder.HasMany(x => x.Objetivos)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Custos
            builder.HasMany(x => x.Custos)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Justifativas
            builder.HasMany(x => x.Justificativas)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Restricoes
            builder.HasMany(x => x.Restricoes)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Riscos
            builder.HasMany(x => x.Riscos)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Beneficios
            builder.HasMany(x => x.Beneficios)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Premissas
            builder.HasMany(x => x.Premissas)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : MarcosEntregas
            builder.HasMany(x => x.MarcosEntregas)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Requisitos
            builder.HasMany(x => x.Requisitos)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Escopo
            builder.HasMany(x => x.Escopos)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Não Escopo
            builder.HasMany(x => x.NaoEscopos)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : N => Projeto : Arquivos
            builder.HasMany(x => x.Arquivos)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.CO_PROJETO);

            // 1 : 1 => Usuario -> Patrocinador
            builder.HasOne(x => x.Patrocinador)
                .WithMany(x => x.ProjetosPatrocinador)
                .HasForeignKey(x => x.MATRICULA_PATROCINADOR);

            // 1 : 1 => Usuario -> Gerente
            builder.HasOne(x => x.Gerente)
                .WithMany(x => x.ProjetosGerente)
                .HasForeignKey(x => x.MATRICULA_GERENTE);

            builder.HasOne(x => x.Demandante)
              .WithMany(x => x.ProjetosDemandante)
              .HasForeignKey(x => x.GESTOR_DEMANDANTE);

            builder.HasMany(x => x.ProjetosFilho)
                .WithOne(x => x.ProjetoPai)
                .HasForeignKey(x => x.CO_PROJETO_PAI);

        }
    }
}