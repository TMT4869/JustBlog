using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExpire = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d331023-1622-4337-938b-b02fbec5c41e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "122f8331-95f9-4ad1-896c-24e7773c31c2", "AQAAAAIAAYagAAAAEHXQPh8JYn48T+H0Uv7J+F1qWhy/Vc1Cb6HTvZQCSyd3lB+i81ibYu5DoBdQSzR9Jw==", "8f507d16-16ec-432f-a3ac-aa312ce3482c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cab68f9e-3196-489a-9c64-77409619e6b5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a4f4353-a3b1-4de2-9718-9c4e687af492", "AQAAAAIAAYagAAAAEBpEdyS9yvPBTukA71aaP+Q5Vys9++wnpF1ovyXOQKy8YtZzLO0PauC/Agc/77D/uQ==", "8069b4d3-5827-4f79-a2b3-607f5335cc00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba58c71-263a-4060-b606-c7efe2ed8ef9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef86bc1f-9bc4-4f4d-9674-8a005113c888", "AQAAAAIAAYagAAAAEPOqo4dqLqI7Nj3IKjnxWR9uHAqoHvxl4xGfRYP1LNEe62/EfPucmhJi6llZ4jeeCg==", "7e614c76-c189-47cd-94a9-b207a5527392" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("edde2618-6e41-462b-93e2-cd8d9ce0bacb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "239d9149-8ee1-446b-b7ad-1abe4fefbefd", "AQAAAAIAAYagAAAAEKA07mZY96oCb+PhwDp6+t1wGf4VOUf4pav6r1/nB1g/mF276XGophNUS6JUgHFaLA==", "6e4742cf-4438-4282-9dc0-7e37c90c60ce" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d331023-1622-4337-938b-b02fbec5c41e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d9c8f9f-52c6-41ff-bedc-197dd05f0d7e", "AQAAAAIAAYagAAAAENDdskgpzAXDKjHAk6OWL6VaCqgm7vqgpXLNJKNKWsxibdvSsqUPC0TOHtZql0RFCA==", "4da6f1e7-eda4-435d-bd7a-13c64e097009" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cab68f9e-3196-489a-9c64-77409619e6b5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b7f4b75-d515-40c1-99c5-cdc80a1a0d78", "AQAAAAIAAYagAAAAEI3NsOqAj7xzAg4WsPSuptCpkN/Sc6gU7jlFeI9I71+X0hxoh7wto9BggRjB2w2Kyw==", "6792e721-3b18-49d7-9454-b63c9c8b9256" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba58c71-263a-4060-b606-c7efe2ed8ef9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3733faa5-36a3-4b0b-ab19-76af4998e1f1", "AQAAAAIAAYagAAAAEBVr7b+AoiIQgRU+H7yyyd90gRdtfGhY4aW5o3hkz5j5Yhh6Ad3JKS0hsYa4pN3IAg==", "fb5e2f69-5745-4715-a7e8-e348573c8234" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("edde2618-6e41-462b-93e2-cd8d9ce0bacb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a80fc58-858c-49e6-94ff-6e416cf61800", "AQAAAAIAAYagAAAAEHhIhGERcvDa3QB7RwLXcuaqtEStYdAJ0oiMVZNn2Hw9ptwx6CKFWpPOB4caaF35vg==", "ee5be25c-814a-4bbb-94cc-e6ebfae8424f" });
        }
    }
}
