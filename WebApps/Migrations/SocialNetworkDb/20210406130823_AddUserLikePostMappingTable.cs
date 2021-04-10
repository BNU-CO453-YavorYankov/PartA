using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApps.Migrations.SocialNetworkDb
{
    public partial class AddUserLikePostMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersLikePosts",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLikePosts", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UsersLikePosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsersLikePosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersLikePosts_PostId",
                table: "UsersLikePosts",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersLikePosts");
        }
    }
}
