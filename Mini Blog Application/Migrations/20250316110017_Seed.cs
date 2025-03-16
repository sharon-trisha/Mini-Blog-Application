using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mini_Blog_Application.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a696449-ec0b-4ade-bd89-53b6b6292aa1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a01b43b3-d6a1-467e-8aff-2f0fbebbd319");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08beacc0-38dd-42a9-82c1-c3706a0cf19e", "08beacc0-38dd-42a9-82c1-c3706a0cf19e", "User", "USER" },
                    { "6ac343b0-00ef-4a1c-8f64-68daaca77b5b", "6ac343b0-00ef-4a1c-8f64-68daaca77b5b", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08beacc0-38dd-42a9-82c1-c3706a0cf19e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ac343b0-00ef-4a1c-8f64-68daaca77b5b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a696449-ec0b-4ade-bd89-53b6b6292aa1", null, "User", "USER" },
                    { "a01b43b3-d6a1-467e-8aff-2f0fbebbd319", null, "Admin", "ADMIN" }
                });
        }
    }
}
