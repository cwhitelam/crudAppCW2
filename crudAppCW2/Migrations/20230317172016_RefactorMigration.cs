using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudAppCW2.Migrations
{
    /// <inheritdoc />
    public partial class RefactorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Notification",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Notification",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Notification",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Notification",
                newName: "Body");
        }
    }
}
