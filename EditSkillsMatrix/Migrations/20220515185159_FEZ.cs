using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditSkillsMatrix.Migrations
{
    public partial class FEZ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "Question",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Answer",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Question",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Answer",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
