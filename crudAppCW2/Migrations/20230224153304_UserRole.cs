using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudAppCW2.Migrations
{
    /// <inheritdoc />
    public partial class UserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDepartments_Departments_DepartmentId",
                table: "UserDepartments");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "UserDepartments",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDepartments_DepartmentId",
                table: "UserDepartments",
                newName: "IX_UserDepartments_RoleId");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserDepartments_Role_RoleId",
                table: "UserDepartments",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDepartments_Role_RoleId",
                table: "UserDepartments");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserDepartments",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDepartments_RoleId",
                table: "UserDepartments",
                newName: "IX_UserDepartments_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDepartments_Departments_DepartmentId",
                table: "UserDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
