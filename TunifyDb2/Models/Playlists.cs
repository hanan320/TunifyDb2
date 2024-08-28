namespace TunifyDb2.Models
{
    public class Playlists
    {
        public int PlaylistsId { get; set; }
        public int User_Id { get; set; }//FK
        public string Playlists_Name { get; set; }
        public string Created_Date { get; set; }
    }
}
