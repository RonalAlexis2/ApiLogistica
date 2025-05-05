using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticaApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposDescuento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "EnviosTerrestres",
                newName: "PlacaVehiculo");

            migrationBuilder.RenameColumn(
                name: "Destino",
                table: "EnviosTerrestres",
                newName: "NumeroGuia");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntrega",
                table: "EnviosTerrestres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioConDescuento",
                table: "EnviosTerrestres",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioEnvio",
                table: "EnviosTerrestres",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioNormal",
                table: "EnviosTerrestres",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioConDescuento",
                table: "EnviosMaritimos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioNormal",
                table: "EnviosMaritimos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaEntrega",
                table: "EnviosTerrestres");

            migrationBuilder.DropColumn(
                name: "PrecioConDescuento",
                table: "EnviosTerrestres");

            migrationBuilder.DropColumn(
                name: "PrecioEnvio",
                table: "EnviosTerrestres");

            migrationBuilder.DropColumn(
                name: "PrecioNormal",
                table: "EnviosTerrestres");

            migrationBuilder.DropColumn(
                name: "PrecioConDescuento",
                table: "EnviosMaritimos");

            migrationBuilder.DropColumn(
                name: "PrecioNormal",
                table: "EnviosMaritimos");

            migrationBuilder.RenameColumn(
                name: "PlacaVehiculo",
                table: "EnviosTerrestres",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "NumeroGuia",
                table: "EnviosTerrestres",
                newName: "Destino");
        }
    }
}
