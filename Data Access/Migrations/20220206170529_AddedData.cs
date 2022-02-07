using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                schema: "data",
                table: "accounts",
                columns: new[] { "Id", "Balance", "Rib" },
                values: new object[] { 1L, 9800.0, 546987536L });

            migrationBuilder.InsertData(
                schema: "data",
                table: "accounts",
                columns: new[] { "Id", "Balance", "Rib" },
                values: new object[] { 2L, 1500.0, 125489639L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "data",
                table: "accounts",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "data",
                table: "accounts",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "data",
                table: "accounts",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "date('now')");
        }
    }
}
