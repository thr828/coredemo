using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class _20230530 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_T_ArticleS_BeArticleId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_BeArticleId",
                table: "Comment");

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("14d6c176-bb69-41dd-addf-188b8e2ff605"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("60431df2-0048-4545-848a-49f226e116ce"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("6a120b42-95ae-49a3-ac38-bf0018099fc7"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("c78f2172-a0c5-4db1-94cc-b92e71abf9fa"));

            migrationBuilder.DropColumn(
                name: "BeArticleId",
                table: "Comment");

            migrationBuilder.InsertData(
                table: "T_ArticleS",
                columns: new[] { "Id", "Author", "CreateTime", "CreateUser", "Description", "Title", "UpdateTime", "UpdateUser", "Version" },
                values: new object[,]
                {
                    { new Guid("40827078-33a6-4e20-9f7c-060316edf252"), "jack", new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6154), "admin", "crm", "迅达crm", new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6164), "admin", 0 },
                    { new Guid("89516b88-5c52-4795-8968-a8d918382828"), "john", new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6227), "admin", "good", "good", new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6228), "admin", 0 },
                    { new Guid("cb3b23de-5e86-4558-9578-c74e1691e15e"), "rock", new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6225), "admin", "tuoxin", "tuoxin", new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6226), "admin", 0 },
                    { new Guid("da6a58aa-bfdf-47c4-9c5f-a6401783a1f5"), "jimmiy", new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6223), "admin", "efrqc", "efrqc", new DateTime(2023, 5, 30, 14, 23, 49, 9, DateTimeKind.Local).AddTicks(6223), "admin", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("40827078-33a6-4e20-9f7c-060316edf252"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("89516b88-5c52-4795-8968-a8d918382828"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("cb3b23de-5e86-4558-9578-c74e1691e15e"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("da6a58aa-bfdf-47c4-9c5f-a6401783a1f5"));

            migrationBuilder.AddColumn<Guid>(
                name: "BeArticleId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "T_ArticleS",
                columns: new[] { "Id", "Author", "CreateTime", "CreateUser", "Description", "Title", "UpdateTime", "UpdateUser", "Version" },
                values: new object[,]
                {
                    { new Guid("14d6c176-bb69-41dd-addf-188b8e2ff605"), "john", new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3536), "admin", "good", "good", new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3537), "admin", 0 },
                    { new Guid("60431df2-0048-4545-848a-49f226e116ce"), "jimmiy", new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3522), "admin", "efrqc", "efrqc", new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3522), "admin", 0 },
                    { new Guid("6a120b42-95ae-49a3-ac38-bf0018099fc7"), "rock", new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3534), "admin", "tuoxin", "tuoxin", new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3535), "admin", 0 },
                    { new Guid("c78f2172-a0c5-4db1-94cc-b92e71abf9fa"), "jack", new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3485), "admin", "crm", "迅达crm", new DateTime(2023, 5, 24, 11, 21, 23, 6, DateTimeKind.Local).AddTicks(3495), "admin", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BeArticleId",
                table: "Comment",
                column: "BeArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_T_ArticleS_BeArticleId",
                table: "Comment",
                column: "BeArticleId",
                principalTable: "T_ArticleS",
                principalColumn: "Id");
        }
    }
}
