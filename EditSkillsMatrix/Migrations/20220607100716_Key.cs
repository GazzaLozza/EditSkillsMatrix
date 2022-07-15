using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditSkillsMatrix.Migrations
{
    public partial class Key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Teams_TeamModId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "TeamModId",
                table: "Teams",
                newName: "TeamModTeamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teams",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_TeamModId",
                table: "Teams",
                newName: "IX_Teams_TeamModTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Teams_TeamModTeamId",
                table: "Teams",
                column: "TeamModTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Teams_TeamModTeamId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "TeamModTeamId",
                table: "Teams",
                newName: "TeamModId");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Teams",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_TeamModTeamId",
                table: "Teams",
                newName: "IX_Teams_TeamModId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Teams_TeamModId",
                table: "Teams",
                column: "TeamModId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
