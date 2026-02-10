using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project5.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "AvailableCopies", "Genre", "Title" },
                values: new object[] { 1, "George Orwell", 3, "Dystopian", "1984" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "AvailableCopies", "Genre", "Title" },
                values: new object[] { 2, "George Orwelll", 6, "Dystopian", "1985" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "AvailableCopies", "Genre", "Title" },
                values: new object[] { 3, "Georgee Orwell", 10, "Dystopiann", "1986" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
