using Microsoft.EntityFrameworkCore.Migrations;

namespace CodePepperInterview.DAL.EF.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Planet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Name", "Planet" },
                values: new object[,]
                {
                    { 1, "Luke Skywalker", null },
                    { 2, "Darth Vader", null },
                    { 3, "Han Solo", null },
                    { 4, "Leia Organa", "Alderaan" },
                    { 5, "Wilhuff Tarkin", "Alderaan--" },
                    { 6, "C-3PO", null },
                    { 7, "R2-D2", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
