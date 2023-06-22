using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeworkPustok.Migrations
{
    public partial class addColumnSlide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "SlideLocation",
                table: "Sliders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlideLocation",
                table: "Sliders");
        }
    }
}
