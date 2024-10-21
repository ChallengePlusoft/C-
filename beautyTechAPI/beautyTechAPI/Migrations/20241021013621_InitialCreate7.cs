using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace beautyTechAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BT_PRODUTO",
                table: "BT_PRODUTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BT_EMPRESA",
                table: "BT_EMPRESA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BT_CLIENTE",
                table: "BT_CLIENTE");

            migrationBuilder.RenameTable(
                name: "BT_PRODUTO",
                newName: "BT_K_PRODUTO");

            migrationBuilder.RenameTable(
                name: "BT_EMPRESA",
                newName: "BT_K_EMPRESA");

            migrationBuilder.RenameTable(
                name: "BT_CLIENTE",
                newName: "BT_K_CLIENTE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BT_K_PRODUTO",
                table: "BT_K_PRODUTO",
                column: "ID_PRODUTO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BT_K_EMPRESA",
                table: "BT_K_EMPRESA",
                column: "ID_EMPRESA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BT_K_CLIENTE",
                table: "BT_K_CLIENTE",
                column: "ID_CLIENTE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BT_K_PRODUTO",
                table: "BT_K_PRODUTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BT_K_EMPRESA",
                table: "BT_K_EMPRESA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BT_K_CLIENTE",
                table: "BT_K_CLIENTE");

            migrationBuilder.RenameTable(
                name: "BT_K_PRODUTO",
                newName: "BT_PRODUTO");

            migrationBuilder.RenameTable(
                name: "BT_K_EMPRESA",
                newName: "BT_EMPRESA");

            migrationBuilder.RenameTable(
                name: "BT_K_CLIENTE",
                newName: "BT_CLIENTE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BT_PRODUTO",
                table: "BT_PRODUTO",
                column: "ID_PRODUTO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BT_EMPRESA",
                table: "BT_EMPRESA",
                column: "ID_EMPRESA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BT_CLIENTE",
                table: "BT_CLIENTE",
                column: "ID_CLIENTE");
        }
    }
}
