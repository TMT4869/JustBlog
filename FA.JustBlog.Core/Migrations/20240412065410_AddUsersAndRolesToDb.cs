using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FA.JustBlog.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersAndRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("87e80a37-565a-4ae0-a48b-0771fedd7d4a"), null, "Contributor", "CONTRIBUTOR" },
                    { new Guid("a927d8cc-a76a-4737-8e82-75152e4d3246"), null, "BlogOwner", "BLOGOWNER" },
                    { new Guid("ac097761-8160-4bf6-91ed-18c8002a1584"), null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("9d331023-1622-4337-938b-b02fbec5c41e"), "I'm a high school detective", 0, 18, "a9f1a6bd-db33-4448-a61f-4e2838974e5a", "shinichi@yahoo.com", true, "Shinichi", "Kudo", false, null, "SHINICHI@YAHOO.COM", "SHINICHI@YAHOO.COM", "AQAAAAIAAYagAAAAEPXt/eETTALWXcJwLHbk3UMCjoD8qj+21NQXg9tvAPyPO2xj2xMNLLmcssah44D3zQ==", null, false, "63225128-cda7-402e-859c-08ce8c066f47", false, "shinichi@yahoo.com" },
                    { new Guid("cba58c71-263a-4060-b606-c7efe2ed8ef9"), "I love Shinichi Kudo", 0, 18, "0e170d63-deb6-46d6-97d1-efdeea83510d", "ran@yahoo.com", true, "Ran", "Mouri", false, null, "RAN@YAHOO.COM", "RAN@YAHOO.COM", "AQAAAAIAAYagAAAAEC+gNJeADze4EQZPje0CWGFzNmS86evT9s6N6ovdJWWPzVoawHqyhMlYzoAeouQ2nA==", null, false, "41ef7f00-a885-462a-b873-aaa5eca861be", false, "ran@yahoo.com" },
                    { new Guid("edde2618-6e41-462b-93e2-cd8d9ce0bacb"), "I'm a software developer", 0, 22, "b27af424-df6b-4ae7-aa5b-603c0d9a2d48", "admin@gmail.com", true, "Hao", "Nguyen", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEOsWdqo3e4qlnrCuwFiCHwy4crD1+NE/J9eB2lAU12Ej8wFmTHaHekOV4JVAFQZl8g==", null, false, "72aed800-548f-41b8-a8bc-0e5bf0a0cafd", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ac097761-8160-4bf6-91ed-18c8002a1584"), new Guid("9d331023-1622-4337-938b-b02fbec5c41e") },
                    { new Guid("ac097761-8160-4bf6-91ed-18c8002a1584"), new Guid("cba58c71-263a-4060-b606-c7efe2ed8ef9") },
                    { new Guid("a927d8cc-a76a-4737-8e82-75152e4d3246"), new Guid("edde2618-6e41-462b-93e2-cd8d9ce0bacb") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87e80a37-565a-4ae0-a48b-0771fedd7d4a"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ac097761-8160-4bf6-91ed-18c8002a1584"), new Guid("9d331023-1622-4337-938b-b02fbec5c41e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ac097761-8160-4bf6-91ed-18c8002a1584"), new Guid("cba58c71-263a-4060-b606-c7efe2ed8ef9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a927d8cc-a76a-4737-8e82-75152e4d3246"), new Guid("edde2618-6e41-462b-93e2-cd8d9ce0bacb") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a927d8cc-a76a-4737-8e82-75152e4d3246"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ac097761-8160-4bf6-91ed-18c8002a1584"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d331023-1622-4337-938b-b02fbec5c41e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cba58c71-263a-4060-b606-c7efe2ed8ef9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("edde2618-6e41-462b-93e2-cd8d9ce0bacb"));
        }
    }
}
