using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareDesignExam.Migrations
{
    /// <inheritdoc />
    public partial class removedItemFromProgramAndDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Item_ItemId",
                table: "Cart");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Stock_ItemId",
                table: "Cart",
                column: "ItemId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Stock_ItemId",
                table: "Cart");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item_Description = table.Column<string>(type: "TEXT", nullable: false),
                    Item_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Item_Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Item_ItemId",
                table: "Cart",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
