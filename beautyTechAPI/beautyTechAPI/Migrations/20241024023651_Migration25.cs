using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beautyTechAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migration25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BT_K_CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CPF_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NM_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_NASCIMENTO_CLIENTE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ESTADO_CIVIL_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PELE_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CABELO_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BT_K_CLIENTE", x => x.ID_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "BT_K_EMPRESA",
                columns: table => new
                {
                    ID_EMPRESA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_EMPRESA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ_EMPRESA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESC_EMPRESA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BT_K_EMPRESA", x => x.ID_EMPRESA);
                });

            migrationBuilder.CreateTable(
                name: "BT_K_PRODUTO",
                columns: table => new
                {
                    ID_PRODUTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_PRODUTO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESC_PRODUTO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    VL_PRODUTO = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    DT_FAB_PRODUTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_VALIDADE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BT_K_PRODUTO", x => x.ID_PRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "BT_K_HISTORICO_PESQUISA",
                columns: table => new
                {
                    ID_HISTORICO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_PRODUTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BT_K_HISTORICO_PESQUISA", x => x.ID_HISTORICO);
                    table.ForeignKey(
                        name: "FK_BT_K_HISTORICO_PESQUISA_BT_K_CLIENTE_ID_CLIENTE",
                        column: x => x.ID_CLIENTE,
                        principalTable: "BT_K_CLIENTE",
                        principalColumn: "ID_CLIENTE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BT_K_HISTORICO_PESQUISA_BT_K_PRODUTO_ID_PRODUTO",
                        column: x => x.ID_PRODUTO,
                        principalTable: "BT_K_PRODUTO",
                        principalColumn: "ID_PRODUTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BT_K_HISTORICO_PESQUISA_ID_CLIENTE",
                table: "BT_K_HISTORICO_PESQUISA",
                column: "ID_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_BT_K_HISTORICO_PESQUISA_ID_PRODUTO",
                table: "BT_K_HISTORICO_PESQUISA",
                column: "ID_PRODUTO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BT_K_EMPRESA");

            migrationBuilder.DropTable(
                name: "BT_K_HISTORICO_PESQUISA");

            migrationBuilder.DropTable(
                name: "BT_K_CLIENTE");

            migrationBuilder.DropTable(
                name: "BT_K_PRODUTO");
        }
    }
}
