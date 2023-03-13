using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.Migrations
{
    public partial class AddNewInvoiceDetails22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InvoiceId1",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId1",
                table: "InvoiceDetails",
                column: "InvoiceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Invoice_InvoiceId1",
                table: "InvoiceDetails",
                column: "InvoiceId1",
                principalTable: "Invoice",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Invoice_InvoiceId1",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_InvoiceId1",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceId1",
                table: "InvoiceDetails");
        }
    }
}
