using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareDesignExam.Migrations
{
    /// <inheritdoc />
    public partial class changedCartRows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Stock_ItemId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ItemId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cart",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Cart",
                newName: "Item_Quantity");

            migrationBuilder.RenameColumn(
                name: "Cart_Item_Quantity",
                table: "Cart",
                newName: "Item_Id");

            migrationBuilder.AddColumn<double>(
                name: "Item_Price",
                table: "Cart",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item_Price",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Cart",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Item_Quantity",
                table: "Cart",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "Item_Id",
                table: "Cart",
                newName: "Cart_Item_Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ItemId",
                table: "Cart",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Stock_ItemId",
                table: "Cart",
                column: "ItemId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
