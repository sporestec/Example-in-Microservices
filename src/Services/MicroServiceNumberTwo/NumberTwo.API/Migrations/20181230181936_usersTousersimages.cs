using Microsoft.EntityFrameworkCore.Migrations;

namespace NumberTwo.API.Migrations
{
    public partial class usersTousersimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UsersImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersImages",
                table: "UsersImages",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersImages",
                table: "UsersImages");

            migrationBuilder.RenameTable(
                name: "UsersImages",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");
        }
    }
}
