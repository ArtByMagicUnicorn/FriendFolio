using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendFolio.Migrations
{
    /// <inheritdoc />
    public partial class FixMemoryBookOwnerColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerEmail",
                table: "MemoryBooks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "MemoryBooks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerEmail",
                table: "MemoryBooks");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "MemoryBooks");
        }
    }
}
