using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G6_BevoTunes.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Songs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Songs");
        }
    }
}
