using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserAddToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DbTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DbTickets_UserId",
                table: "DbTickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbTickets_DbUsers_UserId",
                table: "DbTickets",
                column: "UserId",
                principalTable: "DbUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbTickets_DbUsers_UserId",
                table: "DbTickets");

            migrationBuilder.DropIndex(
                name: "IX_DbTickets_UserId",
                table: "DbTickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DbTickets");
        }
    }
}
