using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudAppCW2.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSelectedRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "User");
        }
    }
}
