using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_Productos_ProductoId",
                table: "VentaDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalles_Ventas_VentaId",
                table: "VentaDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentaDetalles",
                table: "VentaDetalles");

            migrationBuilder.RenameTable(
                name: "VentaDetalles",
                newName: "VentaDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalles_ProductoId",
                table: "VentaDetalle",
                newName: "IX_VentaDetalle_ProductoId");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentaDetalle",
                table: "VentaDetalle",
                columns: new[] { "VentaId", "ProductoId" });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VentaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaProducto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaProducto_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto_ProductoId",
                table: "VentaProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto_VentaId",
                table: "VentaProducto",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalle_Productos_ProductoId",
                table: "VentaDetalle",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalle_Ventas_VentaId",
                table: "VentaDetalle",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalle_Productos_ProductoId",
                table: "VentaDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalle_Ventas_VentaId",
                table: "VentaDetalle");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "VentaProducto");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentaDetalle",
                table: "VentaDetalle");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "VentaDetalle",
                newName: "VentaDetalles");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalle_ProductoId",
                table: "VentaDetalles",
                newName: "IX_VentaDetalles_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentaDetalles",
                table: "VentaDetalles",
                columns: new[] { "VentaId", "ProductoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalles_Productos_ProductoId",
                table: "VentaDetalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalles_Ventas_VentaId",
                table: "VentaDetalles",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
