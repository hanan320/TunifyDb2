namespace TunifyDb2.Models
{
    public class Albums
    {
        public int AlbumsId { get; set; }
        public string Album_Name { get; set; }
        public string Release_Date { get; set; }
        public int Artist_Id { get; set; }//FK
    }
}
