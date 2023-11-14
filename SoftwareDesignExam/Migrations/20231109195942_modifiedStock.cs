using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareDesignExam.Migrations
{
    /// <inheritdoc />
    public partial class modifiedStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item_Id",
                table: "Stock");

            migrationBuilder.AlterColumn<long>(
                name: "Item_Quantity",
                table: "Stock",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Item_Description",
                table: "Stock",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Item_Price",
                table: "Stock",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item_Description",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Item_Price",
                table: "Stock");

            migrationBuilder.AlterColumn<int>(
                name: "Item_Quantity",
                table: "Stock",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Item_Id",
                table: "Stock",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
