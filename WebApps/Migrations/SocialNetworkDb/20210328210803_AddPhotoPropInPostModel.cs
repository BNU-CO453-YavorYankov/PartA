using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApps.Migrations.SocialNetworkDb
{
    public partial class AddPhotoPropInPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Posts",
                newName: "PhotoName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoName",
                table: "Posts",
                newName: "PhotoUrl");
        }
    }
}
