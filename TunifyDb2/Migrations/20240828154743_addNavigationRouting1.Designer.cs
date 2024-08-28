﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TunifyDb2.Data;

#nullable disable

namespace TunifyDb2.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    [Migration("20240828154743_addNavigationRouting1")]
    partial class addNavigationRouting1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TunifyDb2.Models.Albums", b =>
                {
                    b.Property<int>("AlbumsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumsId"));

                    b.Property<string>("Album_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Artist_Id")
                        .HasColumnType("int");

                    b.Property<string>("Release_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlbumsId");

                    b.ToTable("albums");
                });

            modelBuilder.Entity("TunifyDb2.Models.Artists", b =>
                {
                    b.Property<int>("ArtistsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistsId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistsId");

                    b.ToTable("artists");

                    b.HasData(
                        new
                        {
                            ArtistsId = 1,
                            Bio = "Lebanese singer",
                            Name = "Haifa Wehbe"
                        },
                        new
                        {
                            ArtistsId = 2,
                            Bio = "Lebanese singer",
                            Name = "Nancy Ajram"
                        },
                        new
                        {
                            ArtistsId = 3,
                            Bio = "Egyptian singer",
                            Name = "Tamer Hosny"
                        });
                });

            modelBuilder.Entity("TunifyDb2.Models.PlaylistSongs", b =>
                {
                    b.Property<int>("Playlist_Id")
                        .HasColumnType("int");

                    b.Property<int>("Song_Id")
                        .HasColumnType("int");

                    b.HasKey("Playlist_Id", "Song_Id");

                    b.HasIndex("Song_Id");

                    b.ToTable("playlistSongs");

                    b.HasData(
                        new
                        {
                            Playlist_Id = 1,
                            Song_Id = 1
                        },
                        new
                        {
                            Playlist_Id = 2,
                            Song_Id = 3
                        },
                        new
                        {
                            Playlist_Id = 3,
                            Song_Id = 2
                        });
                });

            modelBuilder.Entity("TunifyDb2.Models.Playlists", b =>
                {
                    b.Property<int>("PlaylistsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistsId"));

                    b.Property<string>("Created_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Playlists_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("PlaylistsId");

                    b.ToTable("playlists");

                    b.HasData(
                        new
                        {
                            PlaylistsId = 1,
                            Created_Date = "2024",
                            Playlists_Name = "Road Trip Classics",
                            User_Id = 1
                        },
                        new
                        {
                            PlaylistsId = 2,
                            Created_Date = "2022",
                            Playlists_Name = "Study Focus",
                            User_Id = 2
                        },
                        new
                        {
                            PlaylistsId = 3,
                            Created_Date = "2021",
                            Playlists_Name = "Party Hits",
                            User_Id = 4
                        });
                });

            modelBuilder.Entity("TunifyDb2.Models.Songs", b =>
                {
                    b.Property<int>("SongsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongsId"));

                    b.Property<int>("Album_Id")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongsId");

                    b.HasIndex("ArtistId");

                    b.ToTable("songs");

                    b.HasData(
                        new
                        {
                            SongsId = 1,
                            Album_Id = 1,
                            ArtistId = 1,
                            Duration = "3:53",
                            Genre = "Pop",
                            Title = "Shape of You"
                        },
                        new
                        {
                            SongsId = 2,
                            Album_Id = 2,
                            ArtistId = 2,
                            Duration = "4:31",
                            Genre = "Funk",
                            Title = "Uptown Funk"
                        },
                        new
                        {
                            SongsId = 3,
                            Album_Id = 4,
                            ArtistId = 3,
                            Duration = "2:02",
                            Genre = "Children's Music",
                            Title = "Veggie Dance"
                        });
                });

            modelBuilder.Entity("TunifyDb2.Models.Subscripions", b =>
                {
                    b.Property<int>("SubscripionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscripionsId"));

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subscripions_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscripionsId");

                    b.ToTable("subscripions");
                });

            modelBuilder.Entity("TunifyDb2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Join_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subscription_ID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "hayaalsughair@gmail.com",
                            Join_Date = "3-8-2024",
                            Subscription_ID = 1,
                            UserName = "Haya"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "yasmenahmad@gmail.com",
                            Join_Date = "5-8-2024",
                            Subscription_ID = 2,
                            UserName = "Yasmen"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "sara2001@gmail.com",
                            Join_Date = "1-8-2024",
                            Subscription_ID = 3,
                            UserName = "Sara"
                        });
                });

            modelBuilder.Entity("TunifyDb2.Models.PlaylistSongs", b =>
                {
                    b.HasOne("TunifyDb2.Models.Playlists", "Playlist")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("Playlist_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunifyDb2.Models.Songs", "Song")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("Song_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("TunifyDb2.Models.Songs", b =>
                {
                    b.HasOne("TunifyDb2.Models.Artists", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunifyDb2.Models.Artists", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("TunifyDb2.Models.Playlists", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("TunifyDb2.Models.Songs", b =>
                {
                    b.Navigation("PlaylistSongs");
                });
#pragma warning restore 612, 618
        }
    }
}
