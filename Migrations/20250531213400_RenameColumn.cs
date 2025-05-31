using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWeb9.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantidadeEtoque",
                table: "Produtos",
                newName: "QuantidadeEstoque");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantidadeEstoque",
                table: "Produtos",
                newName: "QuantidadeEtoque");
        }
    }
}
