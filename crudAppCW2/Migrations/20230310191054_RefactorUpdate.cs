using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudAppCW2.Migrations
{
    /// <inheritdoc />
    public partial class RefactorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Selected",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Selected",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
