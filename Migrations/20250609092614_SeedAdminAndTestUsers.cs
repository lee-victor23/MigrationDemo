using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminAndTestUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Email", "CreatedAt", "IsActive" },
                values: new object[,]
                {
                    {
                        3,
                        "Admin User 1",
                        "admin@example.com",
                        new DateTime(2025, 6, 9, 0, 0, 0, DateTimeKind.Local),
                        true,
                    },
                    {
                        4,
                        "Test User 2",
                        "test@example.com",
                        new DateTime(2025, 6, 9, 0, 0, 0, DateTimeKind.Local),
                        true,
                    },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValues: new object[] { 3, 4 }
            );
        }
    }
}
