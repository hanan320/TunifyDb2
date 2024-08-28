namespace TunifyDb2.Models
{
    public class Songs
    {
        public int SongsId { get; set; }
        public string Title { get; set; }
        public int Artist_Id { get; set; }//FK
        public int Album_Id { get; set; }//FK
        public string Duration { get; set; }
        public string Genre { get; set; }
    }
}
