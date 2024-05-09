using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTradeHub.Migrations
{
    /// <inheritdoc />
    public partial class dbSetFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUserId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_cars_CarId",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "favorites");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_CarId",
                table: "favorites",
                newName: "IX_favorites_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_AppUserId",
                table: "favorites",
                newName: "IX_favorites_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_favorites",
                table: "favorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_AspNetUsers_AppUserId",
                table: "favorites",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_cars_CarId",
                table: "favorites",
                column: "CarId",
                principalTable: "cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favorites_AspNetUsers_AppUserId",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_cars_CarId",
                table: "favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_favorites",
                table: "favorites");

            migrationBuilder.RenameTable(
                name: "favorites",
                newName: "Favorites");

            migrationBuilder.RenameIndex(
                name: "IX_favorites_CarId",
                table: "Favorites",
                newName: "IX_Favorites_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_favorites_AppUserId",
                table: "Favorites",
                newName: "IX_Favorites_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUserId",
                table: "Favorites",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_cars_CarId",
                table: "Favorites",
                column: "CarId",
                principalTable: "cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
