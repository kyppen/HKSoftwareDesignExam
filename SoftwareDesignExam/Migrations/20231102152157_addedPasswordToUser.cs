using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareDesignExam.Migrations
{
    /// <inheritdoc />
    public partial class addedPasswordToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_Password",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Password",
                table: "User");
        }
    }
}
