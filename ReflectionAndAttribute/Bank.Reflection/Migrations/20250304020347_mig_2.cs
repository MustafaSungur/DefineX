using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Reflection.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransaction_PaymentMethods_PaymentMethodId",
                table: "PaymentTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTransaction",
                table: "PaymentTransaction");

            migrationBuilder.RenameTable(
                name: "PaymentTransaction",
                newName: "PaymentTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentTransaction_PaymentMethodId",
                table: "PaymentTransactions",
                newName: "IX_PaymentTransactions_PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTransactions",
                table: "PaymentTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransactions_PaymentMethods_PaymentMethodId",
                table: "PaymentTransactions",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTransactions_PaymentMethods_PaymentMethodId",
                table: "PaymentTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTransactions",
                table: "PaymentTransactions");

            migrationBuilder.RenameTable(
                name: "PaymentTransactions",
                newName: "PaymentTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentTransactions_PaymentMethodId",
                table: "PaymentTransaction",
                newName: "IX_PaymentTransaction_PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTransaction",
                table: "PaymentTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTransaction_PaymentMethods_PaymentMethodId",
                table: "PaymentTransaction",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
