using Microsoft.EntityFrameworkCore;
using TunifyDb2.Data;
using TunifyDb2.Repositories.Interfaces;
using TunifyDb2.Repositories.Services;

namespace TunifyDb2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));

            builder.Services.AddTransient<IUser, UserServices>();
            builder.Services.AddTransient<ISong, SongServices>();
            builder.Services.AddTransient<IPlayList, PlaylistsServices>();
            builder.Services.AddTransient<IArtists, ArtistsServices>();

            var app = builder.Build();

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
