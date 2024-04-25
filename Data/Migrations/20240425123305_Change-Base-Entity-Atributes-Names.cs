using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBaseEntityAtributesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "User",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "User",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "User",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SocialNetwork",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "SocialNetwork",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "SocialNetwork",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "SocialNetwork",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PostImage",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PostImage",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "PostImage",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PostImage",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PostGroup",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PostGroup",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "PostGroup",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PostGroup",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Post",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Post",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "Post",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Post",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Image",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Image",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "Image",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Image",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Company",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Company",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "Company",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Company",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Account",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Account",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "Account",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Account",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "User",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "User",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "User",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SocialNetwork",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "SocialNetwork",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "SocialNetwork",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "SocialNetwork",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PostImage",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "PostImage",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "PostImage",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PostImage",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PostGroup",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "PostGroup",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "PostGroup",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PostGroup",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Post",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Post",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Post",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Post",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Image",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Image",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Image",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Image",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Company",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Company",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Company",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Company",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Account",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Account",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Account",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Account",
                newName: "created_at");
        }
    }
}
