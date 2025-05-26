using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientsAndCoffeeOfTheDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffees_CoffeeTypes_CoffeeTypeId",
                table: "Coffees");

            migrationBuilder.RenameColumn(
                name: "CoffeeTypeId",
                table: "Coffees",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Coffees_CoffeeTypeId",
                table: "Coffees",
                newName: "IX_Coffees_TypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Coffees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CoffeeOfTheDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoffeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeOfTheDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeeOfTheDay_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeIngredients",
                columns: table => new
                {
                    CoffeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeIngredients", x => new { x.CoffeeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_CoffeeIngredients_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeIngredients_IngredientId",
                table: "CoffeeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeOfTheDay_CoffeeId",
                table: "CoffeeOfTheDay",
                column: "CoffeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffees_CoffeeTypes_TypeId",
                table: "Coffees",
                column: "TypeId",
                principalTable: "CoffeeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffees_CoffeeTypes_TypeId",
                table: "Coffees");

            migrationBuilder.DropTable(
                name: "CoffeeIngredients");

            migrationBuilder.DropTable(
                name: "CoffeeOfTheDay");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Coffees",
                newName: "CoffeeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Coffees_TypeId",
                table: "Coffees",
                newName: "IX_Coffees_CoffeeTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Coffees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffees_CoffeeTypes_CoffeeTypeId",
                table: "Coffees",
                column: "CoffeeTypeId",
                principalTable: "CoffeeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
