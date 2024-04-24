using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTradeHub.Migrations
{
    /// <inheritdoc />
    public partial class FixStWheel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "SteeringWheel",
                table: "cars",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "SteeringWheel",
                table: "cars",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");
        }
    }
}
