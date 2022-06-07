using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EditSkillsMatrix.Migrations
{
    public partial class Redo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    DTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.ID);
                });

            //migrationBuilder.CreateTable(
            //    name: "Bookings",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Time = table.Column<int>(type: "int", nullable: false),
            //        Rating = table.Column<int>(type: "int", nullable: false),
            //        PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
            //            .Annotation("SqlServer:IsTemporal", true)
            //            .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
            //            .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
            //        PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
            //            .Annotation("SqlServer:IsTemporal", true)
            //            .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
            //            .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bookings", x => x.Id);
            //    })
            //    .Annotation("SqlServer:IsTemporal", true)
            //    .Annotation("SqlServer:TemporalHistoryTableName", "BookingsHistory")
            //    .Annotation("SqlServer:TemporalHistoryTableSchema", null)
            //    .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
            //    .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option1 = table.Column<bool>(type: "bit", nullable: true),
                    Option2 = table.Column<bool>(type: "bit", nullable: true),
                    Option3 = table.Column<bool>(type: "bit", nullable: true),
                    Option4 = table.Column<bool>(type: "bit", nullable: true),
                    Option5 = table.Column<bool>(type: "bit", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    DTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category2",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category2", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Qtypedb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ValuetoDB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qtypedb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subjects = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamModId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Teams_TeamModId",
                        column: x => x.TeamModId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamModId",
                table: "Teams",
                column: "TeamModId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Bookings")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BookingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Category2");

            migrationBuilder.DropTable(
                name: "Qtypedb");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
