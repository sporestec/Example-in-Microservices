using Microsoft.EntityFrameworkCore.Migrations;

namespace NumberTwo.API.Migrations
{
    public partial class updatenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "UsersImages",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersImages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersImages");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UsersImages",
                newName: "id");
        }
    }
}
