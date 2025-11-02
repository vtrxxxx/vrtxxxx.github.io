using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HW12.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.CheckConstraint("CK_Session_EndTime_After_StartTime", "[EndTime] > [StartTime]");
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, "Хакер-компьютерщик узнает от загадочных повстанцев о настоящей сущности своей реальности и о своей роли в войне с ее контроллерами.", "Вачовски", "Фантастика", "Матрица" },
                    { 2, "Вор, который крадет корпоративные тайны с помощью технологии обмена снами, получает задание внедрить идею в сознание генерального директора.", "Кристофер Нолан", "Фантастика", "Начало" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "EndTime", "MovieId", "RoomName", "StartDate", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 16, 30, 0, 0), 1, "Room1", new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 14, 30, 0, 0) },
                    { 2, new TimeSpan(0, 20, 0, 0, 0), 1, "Room2", new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 18, 0, 0, 0) },
                    { 3, new TimeSpan(0, 17, 0, 0, 0), 2, "Room3", new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 15, 0, 0, 0) },
                    { 4, new TimeSpan(0, 21, 0, 0, 0), 2, "Room4", new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 19, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
