namespace TunifyDb2.Models
{
    public class PlaylistSongs
    {
        public int PlaylistSongsId { get; set; }//PK
        public int Playlist_Id { get; set; }//FK
        public int Song_Id { get; set; }//FK
    }
}
