using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyDb2.Migrations
{
    /// <inheritdoc />
    public partial class addPlaylistsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    PlaylistsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(name: "User_Id", type: "int", nullable: false),
                    PlaylistsName = table.Column<string>(name: "Playlists_Name", type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(name: "Created_Date", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.PlaylistsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlists");
        }
    }
}
