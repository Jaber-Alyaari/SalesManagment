using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.Migrations
{
    public partial class ReceiptAndinvoiceAndUserRlation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AUser_ID",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "MUser_ID",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "AUser_ID",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "MUser_ID",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "Customer_ID",
                table: "Receipt",
                newName: "Remarks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiDate",
                table: "Receipt",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiDate",
                table: "Invoice",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "Receipt",
                newName: "Customer_ID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiDate",
                table: "Receipt",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AUser_ID",
                table: "Receipt",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MUser_ID",
                table: "Receipt",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiDate",
                table: "Invoice",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AUser_ID",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MUser_ID",
                table: "Invoice",
                type: "int",
                nullable: true);
        }
    }
}
