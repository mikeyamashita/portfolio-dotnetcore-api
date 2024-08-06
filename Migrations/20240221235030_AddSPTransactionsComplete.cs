using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSPTransactionsComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AmountCredited",
                table: "SPTransactions",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "AmountDebited",
                table: "SPTransactions",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlockchainTransactionId",
                table: "SPTransactions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BuySellRate",
                table: "SPTransactions",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditCurrency",
                table: "SPTransactions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "SPTransactions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebitCurrency",
                table: "SPTransactions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "SPTransactions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceDestination",
                table: "SPTransactions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SpotRate",
                table: "SPTransactions",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountCredited",
                table: "SPTransactions");

            migrationBuilder.DropColumn(
                name: "AmountDebited",
                table: "SPTransactions");

            migrationBuilder.DropColumn(
                name: "BlockchainTransactionId",
                table: "SPTransactions");

            migrationBuilder.DropColumn(
                name: "BuySellRate",
                table: "SPTransactions");

            migrationBuilder.DropColumn(
                name: "CreditCurrency",
                table: "SPTransactions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "SPTransactions");

            migrationBuilder.DropColumn(
                name: "DebitCurrency",
                table: "SPTransactions");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "SPTransactions");

            migrationBuilder.DropColumn(
                name: "SourceDestination",
                table: "SPTransactions");

            migrationBuilder.DropColumn(
                name: "SpotRate",
                table: "SPTransactions");
        }
    }
}
