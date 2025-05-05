using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticaApi.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaEnvioMaritimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnviosMaritimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PuertoId = table.Column<int>(type: "int", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnviosMaritimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnviosMaritimos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviosMaritimos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviosMaritimos_Puertos_PuertoId",
                        column: x => x.PuertoId,
                        principalTable: "Puertos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnviosMaritimos_ClienteId",
                table: "EnviosMaritimos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosMaritimos_ProductoId",
                table: "EnviosMaritimos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnviosMaritimos_PuertoId",
                table: "EnviosMaritimos",
                column: "PuertoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnviosMaritimos");
        }
    }
}
