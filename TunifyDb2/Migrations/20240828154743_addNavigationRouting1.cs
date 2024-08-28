using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunifyDb2.Migrations
{
    /// <inheritdoc />
    public partial class addNavigationRouting1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs");

            migrationBuilder.DropColumn(
                name: "PlaylistSongsId",
                table: "playlistSongs");

            migrationBuilder.RenameColumn(
                name: "Artist_Id",
                table: "songs",
                newName: "ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs",
                columns: new[] { "Playlist_Id", "Song_Id" });

            migrationBuilder.InsertData(
                table: "artists",
                columns: new[] { "ArtistsId", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Lebanese singer", "Haifa Wehbe" },
                    { 2, "Lebanese singer", "Nancy Ajram" },
                    { 3, "Egyptian singer", "Tamer Hosny" }
                });

            migrationBuilder.InsertData(
                table: "playlistSongs",
                columns: new[] { "Playlist_Id", "Song_Id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 1,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { "2024", "Road Trip Classics", 1 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 2,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { "2022", "Study Focus", 2 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 3,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { "2021", "Party Hits", 4 });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 1,
                columns: new[] { "Album_Id", "ArtistId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 2,
                columns: new[] { "Album_Id", "ArtistId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 3,
                columns: new[] { "Album_Id", "ArtistId" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[] { "hayaalsughair@gmail.com", "3-8-2024", 1, "Haya" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[] { "yasmenahmad@gmail.com", "5-8-2024", 2, "Yasmen" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[] { "sara2001@gmail.com", "1-8-2024", 3, "Sara" });

            migrationBuilder.CreateIndex(
                name: "IX_songs_ArtistId",
                table: "songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_Song_Id",
                table: "playlistSongs",
                column: "Song_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_Playlist_Id",
                table: "playlistSongs",
                column: "Playlist_Id",
                principalTable: "playlists",
                principalColumn: "PlaylistsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_songs_Song_Id",
                table: "playlistSongs",
                column: "Song_Id",
                principalTable: "songs",
                principalColumn: "SongsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_artists_ArtistId",
                table: "songs",
                column: "ArtistId",
                principalTable: "artists",
                principalColumn: "ArtistsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_Playlist_Id",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_songs_Song_Id",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_artists_ArtistId",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_ArtistId",
                table: "songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_Song_Id",
                table: "playlistSongs");

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ArtistsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "Playlist_Id", "Song_Id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "Playlist_Id", "Song_Id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "Playlist_Id", "Song_Id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "songs",
                newName: "Artist_Id");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistSongsId",
                table: "playlistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs",
                column: "PlaylistSongsId");

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 1,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 2,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "PlaylistsId",
                keyValue: 3,
                columns: new[] { "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 1,
                columns: new[] { "Album_Id", "Artist_Id" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 2,
                columns: new[] { "Album_Id", "Artist_Id" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 3,
                columns: new[] { "Album_Id", "Artist_Id" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[] { "name1@gmail.com", null, 0, "name1" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[] { "name2@gmail.com", null, 0, "name2" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[] { "name3@gmail.com", null, 0, "name3" });
        }
    }
}
