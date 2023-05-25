using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "T_ArticleS",
                columns: new[] { "Id", "Author", "CreateTime", "CreateUser", "Description", "Title", "UpdateTime", "UpdateUser" },
                values: new object[,]
                {
                    { new Guid("b312e5b1-e914-4c95-8be2-7c2d5de2c214"), "jimmiy", new DateTime(2023, 5, 23, 15, 15, 36, 553, DateTimeKind.Local).AddTicks(8816), "admin", "efrqc", "efrqc", new DateTime(2023, 5, 23, 15, 15, 36, 553, DateTimeKind.Local).AddTicks(8816), "admin" },
                    { new Guid("b8d20d21-44b1-43e4-8c19-8871415761aa"), "jack", new DateTime(2023, 5, 23, 15, 15, 36, 553, DateTimeKind.Local).AddTicks(8779), "admin", "crm", "迅达crm", new DateTime(2023, 5, 23, 15, 15, 36, 553, DateTimeKind.Local).AddTicks(8788), "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("b312e5b1-e914-4c95-8be2-7c2d5de2c214"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("b8d20d21-44b1-43e4-8c19-8871415761aa"));
        }
    }
}
