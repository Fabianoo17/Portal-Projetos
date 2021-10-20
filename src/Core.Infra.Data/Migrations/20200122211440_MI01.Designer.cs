﻿// <auto-generated />
using System;
using Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Infra.Data.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20200122211440_MI01")]
    partial class MI01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Business.Entities.Identity.Perfil", b =>
                {
                    b.Property<int>("PERFIL_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NOME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PERFIL_ID");

                    b.ToTable("T000_PERFIL");
                });

            modelBuilder.Entity("Core.Business.Entities.Identity.Usuario", b =>
                {
                    b.Property<string>("Matricula")
                        .HasColumnName("MATRICULA")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CodigoUnidade")
                        .HasColumnName("NU_UNID_ADM")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnName("NOME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUnidade")
                        .HasColumnName("SG_UNID_ADM")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Matricula");

                    b.ToTable("T000_USUARIOS");
                });

            modelBuilder.Entity("Core.Business.Entities.Identity.UsuarioAcesso", b =>
                {
                    b.Property<string>("MATRICULA")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("MATRICULA");

                    b.ToTable("T000_USUARIO_ACESSO");
                });

            modelBuilder.Entity("Core.Business.Entities.Identity.UsuarioPerfil", b =>
                {
                    b.Property<string>("MATRICULA")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PERFIL_ID")
                        .HasColumnType("int");

                    b.HasKey("MATRICULA", "PERFIL_ID");

                    b.HasIndex("PERFIL_ID");

                    b.ToTable("T000_USUARIO_PERFIL");
                });

            modelBuilder.Entity("Core.Business.Entities.Projeto", b =>
                {
                    b.Property<int>("CO_PROJETO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CAIXA_POSTAL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CO_STATUS")
                        .HasColumnType("int");

                    b.Property<int>("CO_TIPO")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DT_FIM")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DT_INICIO")
                        .HasColumnType("datetime2");

                    b.Property<string>("GERENTE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GESTOR_DEMANDANTE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NO_PROJETO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OBSERVACAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PATROCINADOR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PERCENTUAL")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CO_PROJETO");

                    b.HasIndex("CO_STATUS");

                    b.HasIndex("CO_TIPO");

                    b.ToTable("T003_PROJETOS");
                });

            modelBuilder.Entity("Core.Business.Entities.StatusProjeto", b =>
                {
                    b.Property<int>("CO_STATUS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRICAO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CO_STATUS");

                    b.ToTable("T002_STATUS_PROJETO");
                });

            modelBuilder.Entity("Core.Business.Entities.TipoProjeto", b =>
                {
                    b.Property<int>("CO_TIPO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DESCRICAO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CO_TIPO");

                    b.ToTable("T001_TIPO_PROJETO");
                });

            modelBuilder.Entity("Core.Business.Entities.Identity.UsuarioAcesso", b =>
                {
                    b.HasOne("Core.Business.Entities.Identity.Usuario", "Usuario")
                        .WithMany("UsuariosAcesso")
                        .HasForeignKey("MATRICULA");
                });

            modelBuilder.Entity("Core.Business.Entities.Identity.UsuarioPerfil", b =>
                {
                    b.HasOne("Core.Business.Entities.Identity.UsuarioAcesso", "UsuarioAcesso")
                        .WithMany("UsuarioPerfil")
                        .HasForeignKey("MATRICULA")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Business.Entities.Identity.Perfil", "Perfil")
                        .WithMany("UsuarioPerfis")
                        .HasForeignKey("PERFIL_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Business.Entities.Projeto", b =>
                {
                    b.HasOne("Core.Business.Entities.StatusProjeto", "StatusProjeto")
                        .WithMany("Projetos")
                        .HasForeignKey("CO_STATUS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Business.Entities.TipoProjeto", "TipoProjeto")
                        .WithMany("Projetos")
                        .HasForeignKey("CO_TIPO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
