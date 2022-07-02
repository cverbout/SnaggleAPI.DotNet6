using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnaggleAPI.Migrations
{
    public partial class SnagProjectRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Project",
                table: "Snags");

            migrationBuilder.CreateIndex(
                name: "IX_Snags_ProjectId",
                table: "Snags",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Snags_Projects_ProjectId",
                table: "Snags",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snags_Projects_ProjectId",
                table: "Snags");

            migrationBuilder.DropIndex(
                name: "IX_Snags_ProjectId",
                table: "Snags");

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "Snags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
