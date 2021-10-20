using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infra.Data.Migrations
{
    public partial class ParteInteressada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "CONTEUDO",
                table: "T012_ARQUIVOS");

            migrationBuilder.AddColumn<string>(
                name: "ENDERECO",
                table: "T012_ARQUIVOS",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PERCENTUAL",
                table: "T003_PROJETOS",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "FLAG_ATIVO",
                table: "T000_USUARIOS",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "T000_USUARIO_VINCULADO",
                columns: table => new
                {
                    MATRICULA_GERENTE = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    MATRICULA_VINCULO = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T000_USUARIO_VINCULADO", x => new { x.MATRICULA_GERENTE, x.MATRICULA_VINCULO });
                    table.ForeignKey(
                        name: "FK_T000_USUARIO_VINCULADO_T000_USUARIO_ACESSO_MATRICULA_GERENTE",
                        column: x => x.MATRICULA_GERENTE,
                        principalTable: "T000_USUARIO_ACESSO",
                        principalColumn: "MATRICULA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T000_USUARIO_VINCULADO_T000_USUARIOS_MATRICULA_VINCULO",
                        column: x => x.MATRICULA_VINCULO,
                        principalTable: "T000_USUARIOS",
                        principalColumn: "MATRICULA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T013_PARTES_INTERESSADAS",
                columns: table => new
                {
                    CO_PARTE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    CGC_UND = table.Column<int>(nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T013_PARTES_INTERESSADAS", x => x.CO_PARTE);
                    table.ForeignKey(
                        name: "FK_T013_PARTES_INTERESSADAS_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T000_USUARIO_ACESSO_T000_USUARIOS_MATRICULA",
                table: "T000_USUARIO_ACESSO");

            migrationBuilder.DropTable(
                name: "T000_USUARIO_VINCULADO");

            migrationBuilder.DropTable(
                name: "T013_PARTES_INTERESSADAS");

            migrationBuilder.DropColumn(
                name: "ENDERECO",
                table: "T012_ARQUIVOS");

            migrationBuilder.DropColumn(
                name: "FLAG_ATIVO",
                table: "T000_USUARIOS");

            migrationBuilder.AddColumn<byte[]>(
                name: "CONTEUDO",
                table: "T012_ARQUIVOS",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PERCENTUAL",
                table: "T003_PROJETOS",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_T000_USUARIO_ACESSO_T000_USUARIOS_MATRICULA",
                table: "T000_USUARIO_ACESSO",
                column: "MATRICULA",
                principalTable: "T000_USUARIOS",
                principalColumn: "MATRICULA",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
