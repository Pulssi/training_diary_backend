using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trainingDiaryBackend.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymMove",
                columns: table => new
                {
                    IdGymMove = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    MoveDescription = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GymMove__127ABF0A9AF70158", x => x.IdGymMove);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Person__A5D4E15B3B668184", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "GymSet",
                columns: table => new
                {
                    IdGymSet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGymMove = table.Column<int>(nullable: false),
                    IdPerson = table.Column<int>(nullable: false),
                    Repetitions = table.Column<int>(nullable: false),
                    SetWeight = table.Column<double>(nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GymSet__7CA0CD41285B77DE", x => x.IdGymSet);
                    table.ForeignKey(
                        name: "FK__GymSet__IdGymMov__76969D2E",
                        column: x => x.IdGymMove,
                        principalTable: "GymMove",
                        principalColumn: "IdGymMove",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__GymSet__IdPerson__778AC167",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    IdMeal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(nullable: false),
                    MealName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    MealDescription = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Calories = table.Column<double>(nullable: false),
                    Carbs = table.Column<double>(nullable: true),
                    Fats = table.Column<double>(nullable: true),
                    Proteins = table.Column<double>(nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Meal__4D7C3B3AF07A767D", x => x.IdMeal);
                    table.ForeignKey(
                        name: "FK__Meal__IdPerson__7D439ABD",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weight",
                columns: table => new
                {
                    IdWeight = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Weight__CEE0A1B62E615389", x => x.IdWeight);
                    table.ForeignKey(
                        name: "FK__Weight__IdPerson__7A672E12",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymSet_IdGymMove",
                table: "GymSet",
                column: "IdGymMove");

            migrationBuilder.CreateIndex(
                name: "IX_GymSet_IdPerson",
                table: "GymSet",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_IdPerson",
                table: "Meal",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_IdPerson",
                table: "Weight",
                column: "IdPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymSet");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Weight");

            migrationBuilder.DropTable(
                name: "GymMove");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
