using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G6_BevoTunes.Migrations
{
    /// <inheritdoc />
    public partial class AddImageProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SongImage",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtistImage",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongImage",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ArtistImage",
                table: "Artists");
        }
    }
}
