using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendFolio.Migrations
{
    /// <inheritdoc />
    public partial class AddEntryPhotoUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "BookEntries",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "BookEntries");
        }
    }
}
