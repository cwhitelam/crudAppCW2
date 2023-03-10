using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudAppCW2.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRefactor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "User",
                newName: "Selected");

            migrationBuilder.AddColumn<bool>(
                name: "IsRestored",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRestored",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Selected",
                table: "User",
                newName: "IsDeleted");
        }
    }
}
