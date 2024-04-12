using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddUserWhoHasRoleContributor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d331023-1622-4337-938b-b02fbec5c41e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d9c8f9f-52c6-41ff-bedc-197dd05f0d7e", "AQAAAAIAAYagAAAAENDdskgpzAXDKjHAk6OWL6VaCqgm7vqgpXLNJKNKWsxibdvSsqUPC0TOHtZql0RFCA==", "4da6f1e7-eda4-435d-bd7a-13c64e097009" });

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("cab68f9e-3196-489a-9c64-77409619e6b5"), "Football player likes to write blogs", 0, 23, "9b7f4b75-d515-40c1-99c5-cdc80a1a0d78", "enzo@chelsea.com", true, "Enzo", "Fernández", false, null, "ENZO@CHELSEA.COM", "ENZO@CHELSEA.COM", "AQAAAAIAAYagAAAAEI3NsOqAj7xzAg4WsPSuptCpkN/Sc6gU7jlFeI9I71+X0hxoh7wto9BggRjB2w2Kyw==", null, false, "6792e721-3b18-49d7-9454-b63c9c8b9256", false, "enzo@chelsea.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("87e80a37-565a-4ae0-a48b-0771fedd7d4a"), new Guid("cab68f9e-3196-489a-9c64-77409619e6b5") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87e80a37-565a-4ae0-a48b-0771fedd7d4a"), new Guid("cab68f9e-3196-489a-9c64-77409619e6b5") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cab68f9e-3196-489a-9c64-77409619e6b5"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d331023-1622-4337-938b-b02fbec5c41e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9f1a6bd-db33-4448-a61f-4e2838974e5a", "AQAAAAIAAYagAAAAEPXt/eETTALWXcJwLHbk3UMCjoD8qj+21NQXg9tvAPyPO2xj2xMNLLmcssah44D3zQ==", "63225128-cda7-402e-859c-08ce8c066f47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba58c71-263a-4060-b606-c7efe2ed8ef9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e170d63-deb6-46d6-97d1-efdeea83510d", "AQAAAAIAAYagAAAAEC+gNJeADze4EQZPje0CWGFzNmS86evT9s6N6ovdJWWPzVoawHqyhMlYzoAeouQ2nA==", "41ef7f00-a885-462a-b873-aaa5eca861be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("edde2618-6e41-462b-93e2-cd8d9ce0bacb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b27af424-df6b-4ae7-aa5b-603c0d9a2d48", "AQAAAAIAAYagAAAAEOsWdqo3e4qlnrCuwFiCHwy4crD1+NE/J9eB2lAU12Ej8wFmTHaHekOV4JVAFQZl8g==", "72aed800-548f-41b8-a8bc-0e5bf0a0cafd" });
        }
    }
}
