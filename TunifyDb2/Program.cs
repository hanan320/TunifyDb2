using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TunifyDb2.Data;
using TunifyDb2.Models;
using TunifyDb2.Repositories.Interfaces;
using TunifyDb2.Repositories.Services;
using TunifyPlatform.Repositories.Interfaces;
using TunifyPlatform.Repositories.Services;


namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            // Identity configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TunifyDbContext>();

            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));
            builder.Services.AddTransient<IUser, UserServices>();
            builder.Services.AddTransient<ISong, SongServices>();
            builder.Services.AddTransient<IPlayList, PlaylistsServices>();
            builder.Services.AddTransient<IArtists,ArtistsServices>();

            builder.Services.AddTransient<IAccounts, IdentityAccountService>();


            //swager configration 
            builder.Services.AddSwaggerGen(
                option =>
                {
                    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Tunify API",
                        Version = "v1",
                        Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                    });
                }
                );
            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            //Call swagger services
            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             }
             );

            //Call swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });


            app.MapControllers();
            //  app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}