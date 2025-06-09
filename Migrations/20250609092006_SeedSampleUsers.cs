using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleUsers : Migration
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
                        1,
                        "Admin User",
                        "admin@example.com",
                        new DateTime(2025, 6, 9, 0, 0, 0, DateTimeKind.Local),
                        true,
                    },
                    {
                        2,
                        "Test User",
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
                keyValues: new object[] { 1, 2 }
            );
        }
    }
}
