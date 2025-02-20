using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetExam.Business.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "Id", "Codigo", "Descripcion", "Imagen", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, "ART001", "Laptop", "https://http2.mlstatic.com/D_NQ_NP_869818-MLU77724314601_072024-O.webp", 1500.00m, 10 },
                    { 2, "ART002", "Smartphone", "https://http2.mlstatic.com/D_NQ_NP_877416-CBT77139740446_062024-O.webp", 800.00m, 20 },
                    { 3, "ART003", "Tablet", "https://http2.mlstatic.com/D_NQ_NP_709058-MLU78169795366_082024-O.webp", 400.00m, 15 },
                    { 4, "ART004", "Monitor", "https://http2.mlstatic.com/D_NQ_NP_886158-MLA46737528644_072021-O.webp", 250.00m, 25 }
                });

            migrationBuilder.InsertData(
                table: "Tiendas",
                columns: new[] { "Id", "Direccion", "Sucursal" },
                values: new object[,]
                {
                    { 1, "Calle 123", "Tienda A" },
                    { 2, "Avenida 456", "Tienda B" }
                });

            migrationBuilder.InsertData(
                table: "TiendaArticulos",
                columns: new[] { "ArticuloId", "TiendaId", "Fecha" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 20, 15, 48, 44, 729, DateTimeKind.Local).AddTicks(3278) },
                    { 2, 1, new DateTime(2025, 2, 20, 15, 48, 44, 729, DateTimeKind.Local).AddTicks(3288) },
                    { 3, 2, new DateTime(2025, 2, 20, 15, 48, 44, 729, DateTimeKind.Local).AddTicks(3290) },
                    { 4, 2, new DateTime(2025, 2, 20, 15, 48, 44, 729, DateTimeKind.Local).AddTicks(3291) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiendaArticulos",
                keyColumns: new[] { "ArticuloId", "TiendaId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TiendaArticulos",
                keyColumns: new[] { "ArticuloId", "TiendaId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TiendaArticulos",
                keyColumns: new[] { "ArticuloId", "TiendaId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "TiendaArticulos",
                keyColumns: new[] { "ArticuloId", "TiendaId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tiendas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tiendas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
