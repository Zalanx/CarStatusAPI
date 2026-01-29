using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class allMigrationsWrongLatestWithToDo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbToDos_DbTickets_DbTicketId",
                table: "DbToDos");

            migrationBuilder.DropColumn(
                name: "DbUserId",
                table: "DbToDos");

            migrationBuilder.AlterColumn<int>(
                name: "DbTicketId",
                table: "DbToDos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DbToDos_DbTickets_DbTicketId",
                table: "DbToDos",
                column: "DbTicketId",
                principalTable: "DbTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbToDos_DbTickets_DbTicketId",
                table: "DbToDos");

            migrationBuilder.AlterColumn<int>(
                name: "DbTicketId",
                table: "DbToDos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DbUserId",
                table: "DbToDos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DbToDos_DbTickets_DbTicketId",
                table: "DbToDos",
                column: "DbTicketId",
                principalTable: "DbTickets",
                principalColumn: "Id");
        }
    }
}
