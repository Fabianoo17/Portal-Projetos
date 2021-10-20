using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infra.Data.Migrations
{
    public partial class mi02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GERENTE",
                table: "T003_PROJETOS");

            migrationBuilder.DropColumn(
                name: "NO_PROJETO",
                table: "T003_PROJETOS");

            migrationBuilder.DropColumn(
                name: "PATROCINADOR",
                table: "T003_PROJETOS");

            migrationBuilder.AlterColumn<string>(
                name: "OBSERVACAO",
                table: "T003_PROJETOS",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GESTOR_DEMANDANTE",
                table: "T003_PROJETOS",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CAIXA_POSTAL",
                table: "T003_PROJETOS",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DESCRICAO",
                table: "T003_PROJETOS",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_CADASTRO",
                table: "T003_PROJETOS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MATRICULA_GERENTE",
                table: "T003_PROJETOS",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MATRICULA_PATROCINADOR",
                table: "T003_PROJETOS",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOME",
                table: "T003_PROJETOS",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "T002_STATUS_PROJETO",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "T001_TIPO_PROJETO",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SG_UNID_ADM",
                table: "T000_USUARIOS",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "T000_USUARIOS",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MATRICULA",
                table: "T000_USUARIOS",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MATRICULA",
                table: "T000_USUARIO_PERFIL",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "MATRICULA",
                table: "T000_USUARIO_ACESSO",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "T000_PERFIL",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "T004_OBJETIVOS",
                columns: table => new
                {
                    CO_OBJETIVO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T004_OBJETIVOS", x => x.CO_OBJETIVO);
                    table.ForeignKey(
                        name: "FK_T004_OBJETIVOS_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T005_CUSTOS",
                columns: table => new
                {
                    CO_CUSTO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    VALOR = table.Column<decimal>(nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T005_CUSTOS", x => x.CO_CUSTO);
                    table.ForeignKey(
                        name: "FK_T005_CUSTOS_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T006_JUSTIFICATIVAS",
                columns: table => new
                {
                    CO_JUSTIFICATIVA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T006_JUSTIFICATIVAS", x => x.CO_JUSTIFICATIVA);
                    table.ForeignKey(
                        name: "FK_T006_JUSTIFICATIVAS_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T007_RESTRICOES",
                columns: table => new
                {
                    CO_RESTRICAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T007_RESTRICOES", x => x.CO_RESTRICAO);
                    table.ForeignKey(
                        name: "FK_T007_RESTRICOES_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T008_RISCOS",
                columns: table => new
                {
                    CO_RISCO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T008_RISCOS", x => x.CO_RISCO);
                    table.ForeignKey(
                        name: "FK_T008_RISCOS_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T009_BENEFICIOS",
                columns: table => new
                {
                    CO_BENEFICIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T009_BENEFICIOS", x => x.CO_BENEFICIO);
                    table.ForeignKey(
                        name: "FK_T009_BENEFICIOS_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T010_PREMISSAS",
                columns: table => new
                {
                    CO_PREMISSA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T010_PREMISSAS", x => x.CO_PREMISSA);
                    table.ForeignKey(
                        name: "FK_T010_PREMISSAS_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T011_MARCOS_ENTREGAS",
                columns: table => new
                {
                    CO_MARCOS_ENTREGA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T011_MARCOS_ENTREGAS", x => x.CO_MARCOS_ENTREGA);
                    table.ForeignKey(
                        name: "FK_T011_MARCOS_ENTREGAS_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T012_ARQUIVOS",
                columns: table => new
                {
                    CO_ARQUIVO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_PROJETO = table.Column<int>(nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CONTEUDO = table.Column<byte[]>(nullable: true),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T012_ARQUIVOS", x => x.CO_ARQUIVO);
                    table.ForeignKey(
                        name: "FK_T012_ARQUIVOS_T003_PROJETOS_CO_PROJETO",
                        column: x => x.CO_PROJETO,
                        principalTable: "T003_PROJETOS",
                        principalColumn: "CO_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T003_PROJETOS_MATRICULA_GERENTE",
                table: "T003_PROJETOS",
                column: "MATRICULA_GERENTE");

            migrationBuilder.CreateIndex(
                name: "IX_T003_PROJETOS_MATRICULA_PATROCINADOR",
                table: "T003_PROJETOS",
                column: "MATRICULA_PATROCINADOR");

            migrationBuilder.CreateIndex(
                name: "IX_T004_OBJETIVOS_CO_PROJETO",
                table: "T004_OBJETIVOS",
                column: "CO_PROJETO");

            migrationBuilder.CreateIndex(
                name: "IX_T005_CUSTOS_CO_PROJETO",
                table: "T005_CUSTOS",
                column: "CO_PROJETO");

            migrationBuilder.CreateIndex(
                name: "IX_T006_JUSTIFICATIVAS_CO_PROJETO",
                table: "T006_JUSTIFICATIVAS",
                column: "CO_PROJETO");

            migrationBuilder.CreateIndex(
                name: "IX_T007_RESTRICOES_CO_PROJETO",
                table: "T007_RESTRICOES",
                column: "CO_PROJETO");

            migrationBuilder.CreateIndex(
                name: "IX_T008_RISCOS_CO_PROJETO",
                table: "T008_RISCOS",
                column: "CO_PROJETO");

            migrationBuilder.CreateIndex(
                name: "IX_T009_BENEFICIOS_CO_PROJETO",
                table: "T009_BENEFICIOS",
                column: "CO_PROJETO");

            migrationBuilder.CreateIndex(
                name: "IX_T010_PREMISSAS_CO_PROJETO",
                table: "T010_PREMISSAS",
                column: "CO_PROJETO");

            migrationBuilder.CreateIndex(
                name: "IX_T011_MARCOS_ENTREGAS_CO_PROJETO",
                table: "T011_MARCOS_ENTREGAS",
                column: "CO_PROJETO");

            migrationBuilder.CreateIndex(
                name: "IX_T012_ARQUIVOS_CO_PROJETO",
                table: "T012_ARQUIVOS",
                column: "CO_PROJETO");

            migrationBuilder.AddForeignKey(
                name: "FK_T003_PROJETOS_T000_USUARIOS_MATRICULA_GERENTE",
                table: "T003_PROJETOS",
                column: "MATRICULA_GERENTE",
                principalTable: "T000_USUARIOS",
                principalColumn: "MATRICULA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_T003_PROJETOS_T000_USUARIOS_MATRICULA_PATROCINADOR",
                table: "T003_PROJETOS",
                column: "MATRICULA_PATROCINADOR",
                principalTable: "T000_USUARIOS",
                principalColumn: "MATRICULA",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T003_PROJETOS_T000_USUARIOS_MATRICULA_GERENTE",
                table: "T003_PROJETOS");

            migrationBuilder.DropForeignKey(
                name: "FK_T003_PROJETOS_T000_USUARIOS_MATRICULA_PATROCINADOR",
                table: "T003_PROJETOS");

            migrationBuilder.DropTable(
                name: "T004_OBJETIVOS");

            migrationBuilder.DropTable(
                name: "T005_CUSTOS");

            migrationBuilder.DropTable(
                name: "T006_JUSTIFICATIVAS");

            migrationBuilder.DropTable(
                name: "T007_RESTRICOES");

            migrationBuilder.DropTable(
                name: "T008_RISCOS");

            migrationBuilder.DropTable(
                name: "T009_BENEFICIOS");

            migrationBuilder.DropTable(
                name: "T010_PREMISSAS");

            migrationBuilder.DropTable(
                name: "T011_MARCOS_ENTREGAS");

            migrationBuilder.DropTable(
                name: "T012_ARQUIVOS");

            migrationBuilder.DropIndex(
                name: "IX_T003_PROJETOS_MATRICULA_GERENTE",
                table: "T003_PROJETOS");

            migrationBuilder.DropIndex(
                name: "IX_T003_PROJETOS_MATRICULA_PATROCINADOR",
                table: "T003_PROJETOS");

            migrationBuilder.DropColumn(
                name: "DESCRICAO",
                table: "T003_PROJETOS");

            migrationBuilder.DropColumn(
                name: "DT_CADASTRO",
                table: "T003_PROJETOS");

            migrationBuilder.DropColumn(
                name: "MATRICULA_GERENTE",
                table: "T003_PROJETOS");

            migrationBuilder.DropColumn(
                name: "MATRICULA_PATROCINADOR",
                table: "T003_PROJETOS");

            migrationBuilder.DropColumn(
                name: "NOME",
                table: "T003_PROJETOS");

            migrationBuilder.AlterColumn<string>(
                name: "OBSERVACAO",
                table: "T003_PROJETOS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GESTOR_DEMANDANTE",
                table: "T003_PROJETOS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CAIXA_POSTAL",
                table: "T003_PROJETOS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GERENTE",
                table: "T003_PROJETOS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NO_PROJETO",
                table: "T003_PROJETOS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PATROCINADOR",
                table: "T003_PROJETOS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "T002_STATUS_PROJETO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "T001_TIPO_PROJETO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SG_UNID_ADM",
                table: "T000_USUARIOS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "T000_USUARIOS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MATRICULA",
                table: "T000_USUARIOS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MATRICULA",
                table: "T000_USUARIO_PERFIL",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MATRICULA",
                table: "T000_USUARIO_ACESSO",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "T000_PERFIL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
