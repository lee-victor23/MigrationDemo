using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationDemo.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToIsUserActivated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActivated",
                table: "Users",
                newName: "IsUserActivated"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsUserActivated",
                table: "Users",
                newName: "IsActivated"
            );
        }
    }
}
