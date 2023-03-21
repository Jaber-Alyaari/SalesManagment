using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.Migrations
{
    public partial class Receipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    ModifiDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCatch = table.Column<bool>(type: "bit", nullable: true),
                    Customer_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AUser_ID = table.Column<int>(type: "int", nullable: true),
                    MUser_ID = table.Column<int>(type: "int", nullable: true),
                    UserAddId = table.Column<int>(type: "int", nullable: true),
                    UserModifiId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receipt_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_Receipt_Users_UserAddId",
                        column: x => x.UserAddId,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Receipt_Users_UserModifiId",
                        column: x => x.UserModifiId,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_AccountNumber",
                table: "Receipt",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_UserAddId",
                table: "Receipt",
                column: "UserAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_UserModifiId",
                table: "Receipt",
                column: "UserModifiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipt");
        }
    }
}
