using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorProject.Migrations
{
    public partial class Dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4294bf89-36b6-4ba0-b57f-8e48ad7c4544");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51bf863a-7aad-40e0-bfd3-b382d434b91e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a0a8f31-8efe-42e3-acd4-a074883bf989");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf764265-f6bf-4180-b3a7-746593cb7f20", "e607018e-e39b-4f89-8b83-a1f18d71635c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bef486e6-ddf1-41c7-b931-6cec65ccae07", "5fbfc7d0-ef9a-4ef9-a29b-93c16d2c88fe", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95a66b7a-6ff5-4d30-9c42-e63c01dd3e09", "fe99a74c-8641-45ad-8b9e-720ed76b577e", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a66b7a-6ff5-4d30-9c42-e63c01dd3e09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bef486e6-ddf1-41c7-b931-6cec65ccae07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf764265-f6bf-4180-b3a7-746593cb7f20");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51bf863a-7aad-40e0-bfd3-b382d434b91e", "471a1cb4-a85c-409c-940a-9adf66f60dc7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a0a8f31-8efe-42e3-acd4-a074883bf989", "1633c3f3-2ed5-432a-a7d2-8a12fa3035f0", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4294bf89-36b6-4ba0-b57f-8e48ad7c4544", "843e652c-af1c-4e22-8877-d18371de134a", "Employee", "EMPLOYEE" });
        }
    }
}
