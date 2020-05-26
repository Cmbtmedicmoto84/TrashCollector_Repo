using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class PropertyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "WeeklyPickUpDay",
                table: "Customers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e0045ff-245b-46e8-9c0c-09fc6d342231", "feeebe5b-4cb6-4c11-9a8d-580741897898", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a831dbc0-4787-4b7c-828c-29e64aae5b09", "4fdb8f92-d1df-4842-9878-7d5ad80d0111", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3db4373d-cddf-460f-9f72-bed0bf2a6b64", "026a55fb-c385-4688-a90d-cc9a879e9cb0", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e0045ff-245b-46e8-9c0c-09fc6d342231");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3db4373d-cddf-460f-9f72-bed0bf2a6b64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a831dbc0-4787-4b7c-828c-29e64aae5b09");

            migrationBuilder.DropColumn(
                name: "WeeklyPickUpDay",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
