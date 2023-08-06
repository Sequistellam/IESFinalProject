using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FInalprojectAPI.Migrations
{
    public partial class AddAccessibleYears : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessibleYears",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessibleYears",
                table: "AspNetUsers");
        }
    }
}
