namespace TunifyDb2.Models
{
    public class PlaylistSongs
    {
        public int Playlist_Id { get; set; }//FK
        public Playlists Playlist { get; set; }


        public int Song_Id { get; set; }//FK
        public Songs Song { get; set; }
    }
}
