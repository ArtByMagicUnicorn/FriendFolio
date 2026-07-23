using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendFolio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemoryBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    InviteToken = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemoryBookId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEntries_MemoryBooks_MemoryBookId",
                        column: x => x.MemoryBookId,
                        principalTable: "MemoryBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemoryBookId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookQuestions_MemoryBooks_MemoryBookId",
                        column: x => x.MemoryBookId,
                        principalTable: "MemoryBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookEntryId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookQuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAnswers_BookEntries_BookEntryId",
                        column: x => x.BookEntryId,
                        principalTable: "BookEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAnswers_BookQuestions_BookQuestionId",
                        column: x => x.BookQuestionId,
                        principalTable: "BookQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAnswers_BookEntryId",
                table: "BookAnswers",
                column: "BookEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAnswers_BookQuestionId",
                table: "BookAnswers",
                column: "BookQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEntries_MemoryBookId",
                table: "BookEntries",
                column: "MemoryBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookQuestions_MemoryBookId",
                table: "BookQuestions",
                column: "MemoryBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAnswers");

            migrationBuilder.DropTable(
                name: "BookEntries");

            migrationBuilder.DropTable(
                name: "BookQuestions");

            migrationBuilder.DropTable(
                name: "MemoryBooks");
        }
    }
}
