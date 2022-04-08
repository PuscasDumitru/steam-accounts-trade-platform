using Microsoft.EntityFrameworkCore.Migrations;

namespace Axel.Data.Migrations
{
    public partial class AddHtmlContentToAnnouncementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HtmlContent",
                table: "Announcement",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HtmlContent",
                table: "Announcement");
        }
    }
}
