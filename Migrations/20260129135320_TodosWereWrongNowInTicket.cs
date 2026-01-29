using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class TodosWereWrongNowInTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbToDos_DbUsers_DbUserId",
                table: "DbToDos");

            migrationBuilder.DropIndex(
                name: "IX_DbToDos_DbUserId",
                table: "DbToDos");

            migrationBuilder.DropColumn(
                name: "ToDos",
                table: "DbTickets");

            migrationBuilder.AddColumn<int>(
                name: "DbTicketId",
                table: "DbToDos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DbToDos_DbTicketId",
                table: "DbToDos",
                column: "DbTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbToDos_DbTickets_DbTicketId",
                table: "DbToDos",
                column: "DbTicketId",
                principalTable: "DbTickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbToDos_DbTickets_DbTicketId",
                table: "DbToDos");

            migrationBuilder.DropIndex(
                name: "IX_DbToDos_DbTicketId",
                table: "DbToDos");

            migrationBuilder.DropColumn(
                name: "DbTicketId",
                table: "DbToDos");

            migrationBuilder.AddColumn<string>(
                name: "ToDos",
                table: "DbTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DbToDos_DbUserId",
                table: "DbToDos",
                column: "DbUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbToDos_DbUsers_DbUserId",
                table: "DbToDos",
                column: "DbUserId",
                principalTable: "DbUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
