using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("b312e5b1-e914-4c95-8be2-7c2d5de2c214"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("b8d20d21-44b1-43e4-8c19-8871415761aa"));

            migrationBuilder.InsertData(
                table: "T_ArticleS",
                columns: new[] { "Id", "Author", "CreateTime", "CreateUser", "Description", "Title", "UpdateTime", "UpdateUser" },
                values: new object[,]
                {
                    { new Guid("73e4b822-1ee6-4dc1-8bdf-177b69c107b3"), "rock", new DateTime(2023, 5, 23, 15, 19, 56, 894, DateTimeKind.Local).AddTicks(6864), "admin", "tuoxin", "tuoxin", new DateTime(2023, 5, 23, 15, 19, 56, 894, DateTimeKind.Local).AddTicks(6864), "admin" },
                    { new Guid("8c6f2876-c646-48cb-892f-2646c5ecf08d"), "jimmiy", new DateTime(2023, 5, 23, 15, 19, 56, 894, DateTimeKind.Local).AddTicks(6861), "admin", "efrqc", "efrqc", new DateTime(2023, 5, 23, 15, 19, 56, 894, DateTimeKind.Local).AddTicks(6862), "admin" },
                    { new Guid("9c33c5b7-7091-40e2-bfd5-01b0517b21f7"), "john", new DateTime(2023, 5, 23, 15, 19, 56, 894, DateTimeKind.Local).AddTicks(6881), "admin", "good", "good", new DateTime(2023, 5, 23, 15, 19, 56, 894, DateTimeKind.Local).AddTicks(6882), "admin" },
                    { new Guid("cc468cd6-02b2-4c49-8cbb-2f5525c32086"), "jack", new DateTime(2023, 5, 23, 15, 19, 56, 894, DateTimeKind.Local).AddTicks(6825), "admin", "crm", "迅达crm", new DateTime(2023, 5, 23, 15, 19, 56, 894, DateTimeKind.Local).AddTicks(6836), "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("73e4b822-1ee6-4dc1-8bdf-177b69c107b3"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("8c6f2876-c646-48cb-892f-2646c5ecf08d"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("9c33c5b7-7091-40e2-bfd5-01b0517b21f7"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("cc468cd6-02b2-4c49-8cbb-2f5525c32086"));

            migrationBuilder.InsertData(
                table: "T_ArticleS",
                columns: new[] { "Id", "Author", "CreateTime", "CreateUser", "Description", "Title", "UpdateTime", "UpdateUser" },
                values: new object[,]
                {
                    { new Guid("b312e5b1-e914-4c95-8be2-7c2d5de2c214"), "jimmiy", new DateTime(2023, 5, 23, 15, 15, 36, 553, DateTimeKind.Local).AddTicks(8816), "admin", "efrqc", "efrqc", new DateTime(2023, 5, 23, 15, 15, 36, 553, DateTimeKind.Local).AddTicks(8816), "admin" },
                    { new Guid("b8d20d21-44b1-43e4-8c19-8871415761aa"), "jack", new DateTime(2023, 5, 23, 15, 15, 36, 553, DateTimeKind.Local).AddTicks(8779), "admin", "crm", "迅达crm", new DateTime(2023, 5, 23, 15, 15, 36, 553, DateTimeKind.Local).AddTicks(8788), "admin" }
                });
        }
    }
}
