using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationDemo.Migrations
{
    /// <inheritdoc />
    public partial class RenameIsActiveToIsActivatedOnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "IsActive", table: "Users", newName: "IsActivated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "IsActivated", table: "Users", newName: "IsActive");
        }
    }
}
