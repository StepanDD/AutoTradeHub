using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTradeHub.Migrations
{
    /// <inheritdoc />
    public partial class UserInCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "cars",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cars_AppUserId",
                table: "cars",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_AspNetUsers_AppUserId",
                table: "cars",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_AspNetUsers_AppUserId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_AppUserId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "cars");
        }
    }
}
