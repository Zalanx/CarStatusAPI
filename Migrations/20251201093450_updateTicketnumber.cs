using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateTicketnumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticketnumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Current_Ticketnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticketnumber", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbTickets_Ticketnumber",
                table: "DbTickets",
                column: "Ticketnumber");

            migrationBuilder.AddForeignKey(
                name: "FK_DbTickets_Ticketnumber_Ticketnumber",
                table: "DbTickets",
                column: "Ticketnumber",
                principalTable: "Ticketnumber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbTickets_Ticketnumber_Ticketnumber",
                table: "DbTickets");

            migrationBuilder.DropTable(
                name: "Ticketnumber");

            migrationBuilder.DropIndex(
                name: "IX_DbTickets_Ticketnumber",
                table: "DbTickets");
        }
    }
}
