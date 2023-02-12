using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DripChip.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnimalChipperConnectToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Animals_ChipperId",
                table: "Animals",
                column: "ChipperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Users_ChipperId",
                table: "Animals",
                column: "ChipperId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Users_ChipperId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_ChipperId",
                table: "Animals");
        }
    }
}
