using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class programmingTechEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { 1, "Onion", 1 });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { 2, "TreeFrog", 2 });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[] { 3, "ASP.NET", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTechnologies_ProgrammingLanguageId",
                table: "ProgrammingTechnologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingTechnologies");
        }
    }
}
