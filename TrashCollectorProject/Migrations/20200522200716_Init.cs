using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d135c03-8dda-41e8-afc8-d9c3a71190e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf86bc2e-767e-4435-9323-2909e38ee4d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e189ee68-a865-4d1b-b720-61abce0f4709");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44395702-a323-4e4c-a4cb-80f18d4a77c3", "2a7647bf-9c30-4a39-aa82-c01da0f6de78", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6710b9a-0017-4460-a344-db4e5ddb0dc3", "7e5d8b7d-b690-499f-afae-b40dd0c14af9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f618338-1793-4e9d-885a-d64a9849050c", "3afe2cc4-9dd7-4e64-9733-d8c7869a3add", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44395702-a323-4e4c-a4cb-80f18d4a77c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f618338-1793-4e9d-885a-d64a9849050c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6710b9a-0017-4460-a344-db4e5ddb0dc3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d135c03-8dda-41e8-afc8-d9c3a71190e0", "16ee7801-0896-4a6b-81bf-462ddf22ce82", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e189ee68-a865-4d1b-b720-61abce0f4709", "89e7e3d0-2da6-4b8d-87d9-ce937c5ee828", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf86bc2e-767e-4435-9323-2909e38ee4d7", "e688b7a0-77a0-4dc7-a94f-7256bedf28d0", "Employee", "EMPLOYEE" });
        }
    }
}
