using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Colgameplays.Migrations
{
    public partial class Colgameplays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 166, DateTimeKind.Local).AddTicks(3472)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 166, DateTimeKind.Local).AddTicks(5723))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 215, DateTimeKind.Local).AddTicks(9678)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 216, DateTimeKind.Local).AddTicks(1123))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdBrand = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 178, DateTimeKind.Local).AddTicks(9067)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 179, DateTimeKind.Local).AddTicks(857))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consoles_Brands_IdBrand",
                        column: x => x.IdBrand,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addres_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SubTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 187, DateTimeKind.Local).AddTicks(5879))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingSeccions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 198, DateTimeKind.Local).AddTicks(2090)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 198, DateTimeKind.Local).AddTicks(4876))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingSeccions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingSeccions_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 155, DateTimeKind.Local).AddTicks(9385)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 163, DateTimeKind.Local).AddTicks(9207)),
                    IdConsole = table.Column<int>(type: "int", nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Consoles_IdConsole",
                        column: x => x.IdConsole,
                        principalTable: "Consoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdShoppingSeccion = table.Column<int>(type: "int", nullable: false),
                    IdArticle = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 170, DateTimeKind.Local).AddTicks(5307)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 170, DateTimeKind.Local).AddTicks(7031))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Items_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Items_ShoppingSeccions_IdShoppingSeccion",
                        column: x => x.IdShoppingSeccion,
                        principalTable: "ShoppingSeccions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdArticle = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 183, DateTimeKind.Local).AddTicks(1278)),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 17, 23, 40, 23, 183, DateTimeKind.Local).AddTicks(2865))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArticle = table.Column<int>(type: "int", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    Unitprice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addres_IdUser",
                table: "Addres",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdCategory",
                table: "Articles",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdConsole",
                table: "Articles",
                column: "IdConsole");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Items_IdArticle",
                table: "Cart_Items",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Items_IdShoppingSeccion",
                table: "Cart_Items",
                column: "IdShoppingSeccion");

            migrationBuilder.CreateIndex(
                name: "IX_Consoles_IdBrand",
                table: "Consoles",
                column: "IdBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IdArticle",
                table: "Images",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IdArticle",
                table: "OrderDetails",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IdOrder",
                table: "OrderDetails",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdUser",
                table: "Orders",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingSeccions_IdUser",
                table: "ShoppingSeccions",
                column: "IdUser",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addres");

            migrationBuilder.DropTable(
                name: "Cart_Items");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingSeccions");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
