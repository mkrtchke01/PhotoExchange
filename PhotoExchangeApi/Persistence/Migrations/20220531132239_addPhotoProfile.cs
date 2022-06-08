using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoExchangeApi.Persistence.Migrations
{
    public partial class addPhotoProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoProfile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoProfile",
                table: "AspNetUsers");
        }
    }
}
