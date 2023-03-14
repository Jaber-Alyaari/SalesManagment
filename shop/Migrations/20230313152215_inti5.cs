using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.Migrations
{
    public partial class inti5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "InvoiceDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PoNumber",
                table: "Invoice",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "PoNumber",
                table: "Invoice");
        }
    }
}
