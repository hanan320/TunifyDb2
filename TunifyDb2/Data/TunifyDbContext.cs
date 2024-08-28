using Microsoft.EntityFrameworkCore;
using TunifyDb2.Models;

namespace TunifyDb2.Data
{
    public class TunifyDbContext:DbContext
    {
        public TunifyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Subscripions> subscripions { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Artists> artists { get; set; }
        public DbSet<Albums> albums { get; set; }
        public DbSet<Songs> songs { get; set; }
        public DbSet<Playlists> playlists { get; set; }
        public DbSet<PlaylistSongs> playlistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "name1", Email = "name1@gmail.com", Join_Date = "1-1-2001", Subscription_ID = 1 },
                new User { UserId = 2, UserName = "name2", Email = "name2@gmail.com", Join_Date = "1-1-2001", Subscription_ID = 2 },
                new User { UserId = 3, UserName = "name3", Email = "name3@gmail.com", Join_Date = "1-1-2001", Subscription_ID = 3 }
            );
            modelBuilder.Entity<Songs>().HasData(
                new Songs { SongsId = 1, Title = "Shape of You", Artist_Id = 1, Album_Id = 001, Duration = "3:53", Genre = "Pop" },
                new Songs { SongsId = 2, Title = "Uptown Funk", Artist_Id = 2, Album_Id = 002, Duration = "4:31", Genre = "Funk" },
                new Songs { SongsId = 3, Title = "Veggie Dance", Artist_Id = 3, Album_Id = 004, Duration = "2:02", Genre = "Children's Music" }
            );
            modelBuilder.Entity<Playlists>().HasData(
                new Playlists { PlaylistsId = 1, User_Id = 1, Playlists_Name = "Road Trip Classics", Created_Date = "2024" },
                new Playlists { PlaylistsId = 2, User_Id = 2, Playlists_Name = "Study Focus", Created_Date = "2022" },
                new Playlists { PlaylistsId = 3, User_Id = 4, Playlists_Name = "Party Hits", Created_Date = "2021" }
            );

        }
    }
}
