using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "T_ArticleS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_T_ArticleS_BeArticleId",
                        column: x => x.BeArticleId,
                        principalTable: "T_ArticleS",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

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
                name: "Version",
                table: "T_ArticleS");

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
    }
}
