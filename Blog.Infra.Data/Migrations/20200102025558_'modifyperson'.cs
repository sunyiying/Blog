using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infra.Data.Migrations
{
    public partial class modifyperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "Person",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonCode",
                table: "Person",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonCode",
                table: "Person");
        }
    }
}
