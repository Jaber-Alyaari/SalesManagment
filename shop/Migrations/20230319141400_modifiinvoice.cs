using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.Migrations
{
    public partial class modifiinvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Users_User_ID",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "Invoice",
                newName: "UserModifiId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_User_ID",
                table: "Invoice",
                newName: "IX_Invoice_UserModifiId");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiDate",
                table: "Invoice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAddId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UserAddId",
                table: "Invoice",
                column: "UserAddId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Users_UserAddId",
                table: "Invoice",
                column: "UserAddId",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Users_UserModifiId",
                table: "Invoice",
                column: "UserModifiId",
                principalTable: "Users",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Users_UserAddId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Users_UserModifiId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_UserAddId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "AUser_ID",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "MUser_ID",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ModifiDate",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "UserAddId",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "UserModifiId",
                table: "Invoice",
                newName: "User_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_UserModifiId",
                table: "Invoice",
                newName: "IX_Invoice_User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Users_User_ID",
                table: "Invoice",
                column: "User_ID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
