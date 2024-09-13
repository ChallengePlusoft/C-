using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beautyTechAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BT_CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CPF_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NM_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_NASCIMENTO_CLIENTE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ESTADO_CIVIL_CLIENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BT_CLIENTE", x => x.ID_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "BT_EMPRESA",
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
                    table.PrimaryKey("PK_BT_EMPRESA", x => x.ID_EMPRESA);
                });

            migrationBuilder.CreateTable(
                name: "BT_PRODUTO",
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
                    table.PrimaryKey("PK_BT_PRODUTO", x => x.ID_PRODUTO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BT_CLIENTE");

            migrationBuilder.DropTable(
                name: "BT_EMPRESA");

            migrationBuilder.DropTable(
                name: "BT_PRODUTO");
        }
    }
}
