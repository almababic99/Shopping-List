using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Shoppers_ShopperId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ShopperId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ShopperId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopperId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingList_Shoppers_ShopperId",
                        column: x => x.ShopperId,
                        principalTable: "Shoppers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemShoppingList",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    shoppingListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemShoppingList", x => new { x.ItemsId, x.shoppingListsId });
                    table.ForeignKey(
                        name: "FK_ItemShoppingList_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemShoppingList_ShoppingList_shoppingListsId",
                        column: x => x.shoppingListsId,
                        principalTable: "ShoppingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemShoppingList_shoppingListsId",
                table: "ItemShoppingList",
                column: "shoppingListsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_ShopperId",
                table: "ShoppingList",
                column: "ShopperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemShoppingList");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.AddColumn<int>(
                name: "ShopperId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShopperId",
                table: "Items",
                column: "ShopperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Shoppers_ShopperId",
                table: "Items",
                column: "ShopperId",
                principalTable: "Shoppers",
                principalColumn: "Id");
        }
    }
}
