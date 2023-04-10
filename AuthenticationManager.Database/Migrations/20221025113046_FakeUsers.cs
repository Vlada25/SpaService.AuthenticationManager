using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationManager.Database.Migrations
{
    public partial class FakeUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b537ff5-e112-4b87-a05a-38ac06872c72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "635c769f-ec8c-4df9-acd1-6a60019ca9ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "defc078b-1dba-4808-a187-04a2ea8b3c68");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b9836d5-1c94-4fb7-a091-dab195b4569d", "68dab580-3498-4035-b343-c57eaa315153", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54b9012d-77b5-4f93-b690-8a7828a31888", "cd2622bd-4b2e-45c4-8ef9-4bb26074cc87", "Master", "MASTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57559b66-7ce6-4997-b260-7f344e386397", "29ded4b2-5a11-4068-ab1b-42cc762bc4d6", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b9836d5-1c94-4fb7-a091-dab195b4569d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b9012d-77b5-4f93-b690-8a7828a31888");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57559b66-7ce6-4997-b260-7f344e386397");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b537ff5-e112-4b87-a05a-38ac06872c72", "332507d9-1339-4ea6-ab20-d03d262bf5a1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "635c769f-ec8c-4df9-acd1-6a60019ca9ae", "8336e68e-a1b6-429d-9f63-dfc2305c5231", "Master", "MASTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "defc078b-1dba-4808-a187-04a2ea8b3c68", "cb0b84c4-1573-4566-9a0d-fe48e5ba7304", "Manager", "MANAGER" });
        }
    }
}
