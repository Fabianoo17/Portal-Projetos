using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infra.Data.Migrations
{
    public partial class MI01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T000_PERFIL",
                columns: table => new
                {
                    PERFIL_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T000_PERFIL", x => x.PERFIL_ID);
                });

            // migrationBuilder.CreateTable(
            //     name: "T000_USUARIOS",
            //     columns: table => new
            //     {
            //         MATRICULA = table.Column<string>(nullable: false),
            //         NOME = table.Column<string>(nullable: true),
            //         NU_UNID_ADM = table.Column<int>(nullable: true),
            //         SG_UNID_ADM = table.Column<string>(nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_T000_USUARIOS", x => x.MATRICULA);
            //     });

            migrationBuilder.CreateTable(
                name: "T001_TIPO_PROJETO",
                columns: table => new
                {
                    CO_TIPO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T001_TIPO_PROJETO", x => x.CO_TIPO);
                });

            migrationBuilder.CreateTable(
                name: "T002_STATUS_PROJETO",
                columns: table => new
                {
                    CO_STATUS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T002_STATUS_PROJETO", x => x.CO_STATUS);
                });

            migrationBuilder.CreateTable(
                name: "T000_USUARIO_ACESSO",
                columns: table => new
                {
                    MATRICULA = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T000_USUARIO_ACESSO", x => x.MATRICULA);
                    // table.ForeignKey(
                    //     name: "FK_T000_USUARIO_ACESSO_T000_USUARIOS_MATRICULA",
                    //     column: x => x.MATRICULA,
                    //     principalTable: "T000_USUARIOS",
                    //     principalColumn: "MATRICULA",
                    //     onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T003_PROJETOS",
                columns: table => new
                {
                    CO_PROJETO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NO_PROJETO = table.Column<string>(nullable: true),
                    DT_INICIO = table.Column<DateTime>(nullable: true),
                    DT_FIM = table.Column<DateTime>(nullable: true),
                    GERENTE = table.Column<string>(nullable: true),
                    GESTOR_DEMANDANTE = table.Column<string>(nullable: true),
                    PATROCINADOR = table.Column<string>(nullable: true),
                    CO_TIPO = table.Column<int>(nullable: false),
                    CO_STATUS = table.Column<int>(nullable: false),
                    PERCENTUAL = table.Column<decimal>(nullable: false),
                    CAIXA_POSTAL = table.Column<string>(nullable: true),
                    OBSERVACAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T003_PROJETOS", x => x.CO_PROJETO);
                    table.ForeignKey(
                        name: "FK_T003_PROJETOS_T002_STATUS_PROJETO_CO_STATUS",
                        column: x => x.CO_STATUS,
                        principalTable: "T002_STATUS_PROJETO",
                        principalColumn: "CO_STATUS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T003_PROJETOS_T001_TIPO_PROJETO_CO_TIPO",
                        column: x => x.CO_TIPO,
                        principalTable: "T001_TIPO_PROJETO",
                        principalColumn: "CO_TIPO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T000_USUARIO_PERFIL",
                columns: table => new
                {
                    MATRICULA = table.Column<string>(nullable: false),
                    PERFIL_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T000_USUARIO_PERFIL", x => new { x.MATRICULA, x.PERFIL_ID });
                    // table.ForeignKey(
                    //     name: "FK_T000_USUARIO_PERFIL_T000_USUARIO_ACESSO_MATRICULA",
                    //     column: x => x.MATRICULA,
                    //     principalTable: "T000_USUARIO_ACESSO",
                    //     principalColumn: "MATRICULA",
                    //     onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T000_USUARIO_PERFIL_T000_PERFIL_PERFIL_ID",
                        column: x => x.PERFIL_ID,
                        principalTable: "T000_PERFIL",
                        principalColumn: "PERFIL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T000_USUARIO_PERFIL_PERFIL_ID",
                table: "T000_USUARIO_PERFIL",
                column: "PERFIL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T003_PROJETOS_CO_STATUS",
                table: "T003_PROJETOS",
                column: "CO_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_T003_PROJETOS_CO_TIPO",
                table: "T003_PROJETOS",
                column: "CO_TIPO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T000_USUARIO_PERFIL");

            migrationBuilder.DropTable(
                name: "T003_PROJETOS");

            migrationBuilder.DropTable(
                name: "T000_USUARIO_ACESSO");

            migrationBuilder.DropTable(
                name: "T000_PERFIL");

            migrationBuilder.DropTable(
                name: "T002_STATUS_PROJETO");

            migrationBuilder.DropTable(
                name: "T001_TIPO_PROJETO");

            migrationBuilder.DropTable(
                name: "T000_USUARIOS");
        }
    }
}
