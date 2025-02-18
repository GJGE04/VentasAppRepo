using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MontoTotal",
                table: "Ventas",
                newName: "Total");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Ventas",
                newName: "MontoTotal");
        }
    }
}
