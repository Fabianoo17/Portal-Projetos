using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infra.Data.Migrations
{
    public partial class MI03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T003_PROJETOS_T002_STATUS_PROJETO_CO_STATUS",
                table: "T003_PROJETOS");

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_PREVISAO",
                table: "T011_MARCOS_ENTREGAS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "STATUS",
                table: "T011_MARCOS_ENTREGAS",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CO_STATUS",
                table: "T003_PROJETOS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CO_COMPLEXIDADE",
                table: "T003_PROJETOS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CO_PRIORIDADE",
                table: "T003_PROJETOS",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NO_FUNCAO",
                table: "T000_USUARIOS",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "T014_APOIO",
                columns: table => new
                {
                    CO_APOIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    MATRICULA = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T014_APOIO", x => x.CO_APOIO);
                    table.ForeignKey(
                        name: "FK_T014_APOIO_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VW001_UNIDADES",
                columns: table => new
                {
                    NU_UNIDADE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SG_SIGLA = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NO_UNIDADE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NO_RESPONSAVEL = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NU_MATRICULA = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NU_VINC_TI = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    SG_VINC_TI = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NO_VINC_TI = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NU_VINC_ADM = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    SG_VINC_ADM = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NO_VINC_ADM = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VW001_UNIDADES", x => x.NU_UNIDADE);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T013_PARTES_INTERESSADAS_CGC_UND",
                table: "T013_PARTES_INTERESSADAS",
                column: "CGC_UND");

            migrationBuilder.CreateIndex(
                name: "IX_T014_APOIO_CO_PROJETO",
                table: "T014_APOIO",
                column: "CO_PROJETO");

            migrationBuilder.AddForeignKey(
                name: "FK_T003_PROJETOS_T002_STATUS_PROJETO_CO_STATUS",
                table: "T003_PROJETOS",
                column: "CO_STATUS",
                principalTable: "T002_STATUS_PROJETO",
                principalColumn: "CO_STATUS",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_T013_PARTES_INTERESSADAS_VW001_UNIDADES_CGC_UND",
                table: "T013_PARTES_INTERESSADAS",
                column: "CGC_UND",
                principalTable: "VW001_UNIDADES",
                principalColumn: "NU_UNIDADE",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T003_PROJETOS_T002_STATUS_PROJETO_CO_STATUS",
                table: "T003_PROJETOS");

            migrationBuilder.DropForeignKey(
                name: "FK_T013_PARTES_INTERESSADAS_VW001_UNIDADES_CGC_UND",
                table: "T013_PARTES_INTERESSADAS");

            migrationBuilder.DropTable(
                name: "T014_APOIO");

            migrationBuilder.DropTable(
                name: "VW001_UNIDADES");

            migrationBuilder.DropIndex(
                name: "IX_T013_PARTES_INTERESSADAS_CGC_UND",
                table: "T013_PARTES_INTERESSADAS");

            migrationBuilder.DropColumn(
                name: "DT_PREVISAO",
                table: "T011_MARCOS_ENTREGAS");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "T011_MARCOS_ENTREGAS");

            migrationBuilder.DropColumn(
                name: "CO_COMPLEXIDADE",
                table: "T003_PROJETOS");

            migrationBuilder.DropColumn(
                name: "CO_PRIORIDADE",
                table: "T003_PROJETOS");

            migrationBuilder.DropColumn(
                name: "NO_FUNCAO",
                table: "T000_USUARIOS");

            migrationBuilder.AlterColumn<int>(
                name: "CO_STATUS",
                table: "T003_PROJETOS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_T003_PROJETOS_T002_STATUS_PROJETO_CO_STATUS",
                table: "T003_PROJETOS",
                column: "CO_STATUS",
                principalTable: "T002_STATUS_PROJETO",
                principalColumn: "CO_STATUS",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
