using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarStatusAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReworkedToDos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoDto");

            migrationBuilder.CreateTable(
                name: "DbToDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DbUserId = table.Column<int>(type: "int", nullable: false),
                    Todo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    done = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbToDos_DbUsers_DbUserId",
                        column: x => x.DbUserId,
                        principalTable: "DbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbToDos_DbUserId",
                table: "DbToDos",
                column: "DbUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbToDos");

            migrationBuilder.CreateTable(
                name: "ToDoDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DbUserId = table.Column<int>(type: "int", nullable: true),
                    Todo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    done = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoDto_DbUsers_DbUserId",
                        column: x => x.DbUserId,
                        principalTable: "DbUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoDto_DbUserId",
                table: "ToDoDto",
                column: "DbUserId");
        }
    }
}
