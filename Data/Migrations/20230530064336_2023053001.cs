using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class _2023053001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ArticleId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "T_ArticleS",
                columns: new[] { "Id", "Author", "CreateTime", "CreateUser", "Description", "Title", "UpdateTime", "UpdateUser", "Version" },
                values: new object[,]
                {
                    { new Guid("24d3dd6a-5b98-4370-b18f-d237bc565909"), "jimmiy", new DateTime(2023, 5, 30, 14, 43, 36, 141, DateTimeKind.Local).AddTicks(3582), "admin", "efrqc", "efrqc", new DateTime(2023, 5, 30, 14, 43, 36, 141, DateTimeKind.Local).AddTicks(3583), "admin", 0 },
                    { new Guid("7d07c8a5-8b6d-484c-9a98-d5daf0caf46c"), "rock", new DateTime(2023, 5, 30, 14, 43, 36, 141, DateTimeKind.Local).AddTicks(3584), "admin", "tuoxin", "tuoxin", new DateTime(2023, 5, 30, 14, 43, 36, 141, DateTimeKind.Local).AddTicks(3585), "admin", 0 },
                    { new Guid("cfb10e8b-66ac-4fd6-ac13-9febef9d680f"), "jack", new DateTime(2023, 5, 30, 14, 43, 36, 141, DateTimeKind.Local).AddTicks(3548), "admin", "crm", "迅达crm", new DateTime(2023, 5, 30, 14, 43, 36, 141, DateTimeKind.Local).AddTicks(3557), "admin", 0 },
                    { new Guid("e7ac03aa-f212-47f7-b7a4-85aaf9a5866b"), "john", new DateTime(2023, 5, 30, 14, 43, 36, 141, DateTimeKind.Local).AddTicks(3586), "admin", "good", "good", new DateTime(2023, 5, 30, 14, 43, 36, 141, DateTimeKind.Local).AddTicks(3587), "admin", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_T_ArticleS_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "T_ArticleS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_T_ArticleS_ArticleId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment");

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("24d3dd6a-5b98-4370-b18f-d237bc565909"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("7d07c8a5-8b6d-484c-9a98-d5daf0caf46c"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("cfb10e8b-66ac-4fd6-ac13-9febef9d680f"));

            migrationBuilder.DeleteData(
                table: "T_ArticleS",
                keyColumn: "Id",
                keyValue: new Guid("e7ac03aa-f212-47f7-b7a4-85aaf9a5866b"));

            migrationBuilder.DropColumn(
                name: "ArticleId",
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
    }
}