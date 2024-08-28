using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyDb2.Migrations
{
    /// <inheritdoc />
    public partial class addPlaylistSongsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playlistSongs",
                columns: table => new
                {
                    PlaylistSongsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistId = table.Column<int>(name: "Playlist_Id", type: "int", nullable: false),
                    SongId = table.Column<int>(name: "Song_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlistSongs", x => x.PlaylistSongsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlistSongs");
        }
    }
}
