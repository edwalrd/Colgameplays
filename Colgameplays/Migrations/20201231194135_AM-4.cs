using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Colgameplays.Migrations
{
    public partial class AM4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Imagens");

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "12/31/2020 15:41:34",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "12/27/2020 16:50:36");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Ordens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 31, 15, 41, 34, 271, DateTimeKind.Local).AddTicks(6840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 160, DateTimeKind.Local).AddTicks(3457));

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Imagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Carritos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 31, 15, 41, 34, 255, DateTimeKind.Local).AddTicks(9758),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 144, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Articulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 31, 15, 41, 34, 231, DateTimeKind.Local).AddTicks(808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 115, DateTimeKind.Local).AddTicks(8060));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Imagens");

            migrationBuilder.AlterColumn<string>(
                name: "FechaCreacion",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "12/27/2020 16:50:36",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "12/31/2020 15:41:34");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Ordens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 160, DateTimeKind.Local).AddTicks(3457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 31, 15, 41, 34, 271, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.AddColumn<int>(
                name: "Nombre",
                table: "Imagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Carritos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 144, DateTimeKind.Local).AddTicks(4220),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 31, 15, 41, 34, 255, DateTimeKind.Local).AddTicks(9758));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Articulos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 27, 16, 50, 36, 115, DateTimeKind.Local).AddTicks(8060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 31, 15, 41, 34, 231, DateTimeKind.Local).AddTicks(808));
        }
    }
}
