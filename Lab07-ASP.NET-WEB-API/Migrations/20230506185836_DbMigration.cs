using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab07_ASP.NET_WEB_API.Migrations
{
    /// <inheritdoc />
    public partial class DbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "table1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Table1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "table2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Table1Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Table2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table2s_Table1s",
                        column: x => x.Table1Id,
                        principalTable: "table1s",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_table2s_Table1Id",
                table: "table2s",
                column: "Table1Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table2s");

            migrationBuilder.DropTable(
                name: "table1s");
        }
    }
}
