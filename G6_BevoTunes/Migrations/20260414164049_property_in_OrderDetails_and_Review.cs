using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G6_BevoTunes.Migrations
{
    /// <inheritdoc />
    public partial class property_in_OrderDetails_and_Review : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "Reviews",
                newName: "ReviewerID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerID");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ArtistId",
                table: "OrderDetails",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Artists_ArtistId",
                table: "OrderDetails",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerID",
                table: "Reviews",
                column: "ReviewerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Artists_ArtistId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ArtistId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ReviewerID",
                table: "Reviews",
                newName: "ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerID",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
