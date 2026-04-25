using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G6_BevoTunes.Migrations
{
    /// <inheritdoc />
    public partial class CCOptOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustCreditCards_CardCustCreditCardID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CardCustCreditCardID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustCreditCards_CardCustCreditCardID",
                table: "Orders",
                column: "CardCustCreditCardID",
                principalTable: "CustCreditCards",
                principalColumn: "CustCreditCardID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustCreditCards_CardCustCreditCardID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CardCustCreditCardID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustCreditCards_CardCustCreditCardID",
                table: "Orders",
                column: "CardCustCreditCardID",
                principalTable: "CustCreditCards",
                principalColumn: "CustCreditCardID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
