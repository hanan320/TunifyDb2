using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TunifyDb2.Models;

namespace TunifyDb2.Data
{
    public class TunifyDbContext : IdentityDbContext<ApplicationUser>
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlaylistSongs>()
            .HasKey(ps => new { ps.Playlist_Id, ps.Song_Id });

            modelBuilder.Entity<PlaylistSongs>()
                 .HasOne(ps => ps.Playlist)
                 .WithMany(p => p.PlaylistSongs)
                 .HasForeignKey(ps => ps.Playlist_Id);

            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.Song_Id);

            // Configure one-to-many relationship between Artist and Songs
            modelBuilder.Entity<Artists>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistId);

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Haya", Email = "hayaalsughair@gmail.com", Join_Date = "3-8-2024", Subscription_ID = 1 },
                new User { UserId = 2, UserName = "Yasmen", Email = "yasmenahmad@gmail.com", Join_Date = "5-8-2024", Subscription_ID = 2 },
                new User { UserId = 3, UserName = "Sara", Email = "sara2001@gmail.com", Join_Date = "1-8-2024", Subscription_ID = 3 }
            );
            modelBuilder.Entity<Songs>().HasData(
                new Songs { SongsId = 1, Title = "Shape of You", ArtistId = 1, Album_Id = 001, Duration = "3:53", Genre = "Pop" },
                new Songs { SongsId = 2, Title = "Uptown Funk", ArtistId = 2, Album_Id = 002, Duration = "4:31", Genre = "Funk" },
                new Songs { SongsId = 3, Title = "Veggie Dance", ArtistId = 3, Album_Id = 004, Duration = "2:02", Genre = "Children's Music" }
            );
            modelBuilder.Entity<Playlists>().HasData(
                new Playlists { PlaylistsId = 1, User_Id = 1, Playlists_Name = "Road Trip Classics", Created_Date = "2024" },
                new Playlists { PlaylistsId = 2, User_Id = 2, Playlists_Name = "Study Focus", Created_Date = "2022" },
                new Playlists { PlaylistsId = 3, User_Id = 4, Playlists_Name = "Party Hits", Created_Date = "2021" }
            );
            modelBuilder.Entity<Artists>().HasData(
                new Artists { ArtistsId = 1, Name = "Haifa Wehbe", Bio = "Lebanese singer" },
                new Artists { ArtistsId = 2, Name = "Nancy Ajram", Bio = "Lebanese singer" },
                new Artists { ArtistsId = 3, Name = "Tamer Hosny", Bio = "Egyptian singer" }

            );
            modelBuilder.Entity<PlaylistSongs>().HasData(
                new PlaylistSongs { Playlist_Id = 1, Song_Id = 1 },
                new PlaylistSongs { Playlist_Id = 2, Song_Id = 3 },
                new PlaylistSongs { Playlist_Id = 3, Song_Id = 2 }
                );

        }
    }
}
