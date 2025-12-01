using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class BetterTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbUser",
                table: "DbUser");

            migrationBuilder.RenameTable(
                name: "DbUser",
                newName: "DbUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbUsers",
                table: "DbUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DbTicketNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Current_Ticketnumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbTicketNumbers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbTicketNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbUsers",
                table: "DbUsers");

            migrationBuilder.RenameTable(
                name: "DbUsers",
                newName: "DbUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbUser",
                table: "DbUser",
                column: "Id");
        }
    }
}
