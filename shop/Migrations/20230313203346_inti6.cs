using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop.Migrations
{
    public partial class inti6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ReferenceID",
                table: "Journal",
                type: "bigint",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Journal",
                type: "decimal(18,2)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReferenceID",
                table: "Journal",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "Journal",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldFixedLength: true,
                oldMaxLength: 10);
        }
    }
}
