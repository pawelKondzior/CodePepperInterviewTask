using Microsoft.EntityFrameworkCore.Migrations;

namespace CodePepperInterview.DAL.EF.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterFriends",
                columns: table => new
                {
                    RelatingCharacterId = table.Column<int>(nullable: false),
                    RelatedCharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFriends", x => new { x.RelatingCharacterId, x.RelatedCharacterId });
                    table.ForeignKey(
                        name: "FK_CharacterFriend_Characters",
                        column: x => x.RelatedCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterFriend_CharacterFriend",
                        column: x => x.RelatingCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CharacterFriends",
                columns: new[] { "RelatingCharacterId", "RelatedCharacterId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 1, 3 },
                    { 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriends_RelatedCharacterId",
                table: "CharacterFriends",
                column: "RelatedCharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterFriends");
        }
    }
}
