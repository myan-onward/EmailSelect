using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlServerMigrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelectionAssociations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionAssociations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssociationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleSelections_SelectionAssociations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "SelectionAssociations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleId = table.Column<int>(type: "int", nullable: false),
                    RuleSelectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedRule_RuleSelections_RuleSelectionId",
                        column: x => x.RuleSelectionId,
                        principalTable: "RuleSelections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RuleSelections_AssociationId",
                table: "RuleSelections",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedRule_RuleSelectionId",
                table: "SelectedRule",
                column: "RuleSelectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedRule");

            migrationBuilder.DropTable(
                name: "RuleSelections");

            migrationBuilder.DropTable(
                name: "SelectionAssociations");
        }
    }
}
