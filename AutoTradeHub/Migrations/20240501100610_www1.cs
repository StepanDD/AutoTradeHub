using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTradeHub.Migrations
{
    /// <inheritdoc />
    public partial class www1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUserId1",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_AppUserId1",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Favorites");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Favorites",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AppUserId",
                table: "Favorites",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUserId",
                table: "Favorites",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUserId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_AppUserId",
                table: "Favorites");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Favorites",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Favorites",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AppUserId1",
                table: "Favorites",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUserId1",
                table: "Favorites",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
