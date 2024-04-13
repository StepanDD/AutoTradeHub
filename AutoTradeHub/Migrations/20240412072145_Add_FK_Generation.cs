using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTradeHub.Migrations
{
    /// <inheritdoc />
    public partial class Add_FK_Generation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenerationId",
                table: "cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cars_GenerationId",
                table: "cars",
                column: "GenerationId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_generations_GenerationId",
                table: "cars",
                column: "GenerationId",
                principalTable: "generations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_generations_GenerationId",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_GenerationId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "GenerationId",
                table: "cars");
        }
    }
}
