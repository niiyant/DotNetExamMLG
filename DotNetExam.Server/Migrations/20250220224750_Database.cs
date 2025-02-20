using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetExam.Business.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteArticulos",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteArticulos", x => new { x.ClienteId, x.ArticuloId });
                    table.ForeignKey(
                        name: "FK_ClienteArticulos_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteArticulos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiendaArticulos",
                columns: table => new
                {
                    TiendaId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiendaArticulos", x => new { x.TiendaId, x.ArticuloId });
                    table.ForeignKey(
                        name: "FK_TiendaArticulos_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiendaArticulos_Tiendas_TiendaId",
                        column: x => x.TiendaId,
                        principalTable: "Tiendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, 1, new DateTime(2025, 2, 20, 16, 47, 49, 788, DateTimeKind.Local).AddTicks(9024) },
                    { 2, 1, new DateTime(2025, 2, 20, 16, 47, 49, 788, DateTimeKind.Local).AddTicks(9035) },
                    { 3, 2, new DateTime(2025, 2, 20, 16, 47, 49, 788, DateTimeKind.Local).AddTicks(9036) },
                    { 4, 2, new DateTime(2025, 2, 20, 16, 47, 49, 788, DateTimeKind.Local).AddTicks(9037) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteArticulos_ArticuloId",
                table: "ClienteArticulos",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_TiendaArticulos_ArticuloId",
                table: "TiendaArticulos",
                column: "ArticuloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteArticulos");

            migrationBuilder.DropTable(
                name: "TiendaArticulos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Tiendas");
        }
    }
}
