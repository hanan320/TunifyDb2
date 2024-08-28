using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunifyDb2.Migrations
{
    /// <inheritdoc />
    public partial class addAlbumsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    AlbumsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(name: "Album_Name", type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<string>(name: "Release_Date", type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<int>(name: "Artist_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.AlbumsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "albums");
        }
    }
}
