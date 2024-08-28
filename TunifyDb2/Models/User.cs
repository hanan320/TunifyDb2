namespace TunifyDb2.Models
{
    public class User
    {
        public int UserId { get; set; } //PK
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Join_Date { get; set; }
        public int Subscription_ID { get; set; }  //FK
       
    }
}
