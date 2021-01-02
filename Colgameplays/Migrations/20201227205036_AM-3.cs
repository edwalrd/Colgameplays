using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Colgameplays.Migrations
{
    public partial class AM3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carritos_IdArticulo",
                table: "Carritos");

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "12/27/2020 16:50:36",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "12/27/2020 16:32:53");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Ordens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 160, DateTimeKind.Local).AddTicks(3457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 27, 16, 32, 53, 236, DateTimeKind.Local).AddTicks(549));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Carritos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 144, DateTimeKind.Local).AddTicks(4220),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 27, 16, 32, 53, 207, DateTimeKind.Local).AddTicks(6389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Articulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 115, DateTimeKind.Local).AddTicks(8060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 27, 16, 32, 53, 146, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdArticulo",
                table: "Carritos",
                column: "IdArticulo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carritos_IdArticulo",
                table: "Carritos");

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "12/27/2020 16:32:53",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "12/27/2020 16:50:36");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Ordens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 27, 16, 32, 53, 236, DateTimeKind.Local).AddTicks(549),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 160, DateTimeKind.Local).AddTicks(3457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Carritos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 27, 16, 32, 53, 207, DateTimeKind.Local).AddTicks(6389),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 144, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Articulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 27, 16, 32, 53, 146, DateTimeKind.Local).AddTicks(4857),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 115, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdArticulo",
                table: "Carritos",
                column: "IdArticulo");
        }
    }
}
