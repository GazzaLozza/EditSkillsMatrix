using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditSkillsMatrix.Migrations
{
    public partial class changeanswermod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certid",
                table: "Certanswers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Certanswers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Certanswers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Certanswers");

            migrationBuilder.AddColumn<int>(
                name: "Answer",
                table: "Certanswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                table: "Certanswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Certanswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Certanswers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Certanswers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Certanswers");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "Certanswers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Certanswers");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Certanswers");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Certanswers");

            migrationBuilder.AddColumn<string>(
                name: "Certid",
                table: "Certanswers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Certanswers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Certanswers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Certanswers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
