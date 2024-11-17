using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RolePermissionID",
                table: "RolePermissions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PermissionID",
                table: "Permissions",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RolePermissions",
                newName: "RolePermissionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Permissions",
                newName: "PermissionID");
        }
    }
}
