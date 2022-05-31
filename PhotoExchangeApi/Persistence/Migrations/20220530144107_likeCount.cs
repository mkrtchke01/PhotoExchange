using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoExchangeApi.Persistence.Migrations
{
    public partial class likeCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Likes");
        }
    }
}
