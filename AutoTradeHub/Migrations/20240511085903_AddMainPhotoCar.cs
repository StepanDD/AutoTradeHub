using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTradeHub.Migrations
{
    /// <inheritdoc />
    public partial class AddMainPhotoCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "cars",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "cars");
        }
    }
}
