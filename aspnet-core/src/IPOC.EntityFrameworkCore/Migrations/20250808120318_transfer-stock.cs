using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPOC.Migrations
{
    /// <inheritdoc />
    public partial class transferstock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "StockTransfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "StockTransfers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "StockTransfers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StockTransfers");
        }
    }
}
