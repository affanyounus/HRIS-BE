using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRIS.Basic.Migrations
{
    /// <inheritdoc />
    public partial class Addseedsforroleclaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("448c4b6b-d85e-4599-b033-2956d2548924"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d05a6c5-44fd-486b-aa92-df55eeac8cf6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9cfa1e5e-714a-4ab3-a03a-61bb9b4d91b6"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AspNetUserTokens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("14775B04-CD2B-4671-BE90-44E7F733319B"));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("095DDD7C-6315-4323-A44E-CE016CBD30DF"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AspNetUserLogins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4A66AC1A-3680-4106-A4ED-988CAE820C07"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("26bed40f-4db2-4dd6-9478-719340557136"), null, "Admin", "ADMINISTRATOR" },
                    { new Guid("3f6c6e62-6034-4669-9857-49b21d075eac"), null, "Viewer", "VIEWER" },
                    { new Guid("ec173417-5d3c-495c-b598-22ea0c5c346a"), null, "Editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Admin", "Create", new Guid("26bed40f-4db2-4dd6-9478-719340557136") },
                    { 2, "Admin", "Read", new Guid("26bed40f-4db2-4dd6-9478-719340557136") },
                    { 3, "Admin", "Edit", new Guid("26bed40f-4db2-4dd6-9478-719340557136") },
                    { 4, "Admin", "Delete", new Guid("26bed40f-4db2-4dd6-9478-719340557136") },
                    { 5, "Viewer", "Read", new Guid("3f6c6e62-6034-4669-9857-49b21d075eac") },
                    { 6, "Editor", "Edit", new Guid("ec173417-5d3c-495c-b598-22ea0c5c346a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26bed40f-4db2-4dd6-9478-719340557136"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f6c6e62-6034-4669-9857-49b21d075eac"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec173417-5d3c-495c-b598-22ea0c5c346a"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetUserLogins");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("448c4b6b-d85e-4599-b033-2956d2548924"), null, "Admin", "ADMINISTRATOR" },
                    { new Guid("4d05a6c5-44fd-486b-aa92-df55eeac8cf6"), null, "Editor", "EDITOR" },
                    { new Guid("9cfa1e5e-714a-4ab3-a03a-61bb9b4d91b6"), null, "Viewer", "VIEWER" }
                });
        }
    }
}
