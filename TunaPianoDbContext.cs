using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;
using System.Runtime.CompilerServices;

public class TunaPianoDbContext : DbContext
{

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<SongGenre> SongGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
            new Artist
            {
                ID = 1,
                Name = "Taylor Swift",
                Age = 34,
                Bio = "She really likes to sing about her breakups."
            },

            new Artist
            {
                ID = 2,
                Name = "Bruno Mars",
                Age = 38,
                Bio = "Likes to sing songs that get you up and moving!"
            }

        });

        modelBuilder.Entity<Song>().HasData(new Song[]
        {
            new Song
            {
                ID = 1,
                Title = "Bigger Than the Whole Sky",
                ArtistID = 1,
                Album = "Midnights",
                Length = 4
            },

            new Song
            {
                ID = 2,
                Title = "Uptown Funk",
                ArtistID = 2,
                Album = "Uptown Special",
                Length = 4
            }
        });

        modelBuilder.Entity<Genre> ().HasData(new Genre[]
        {  
            new Genre
            {
                ID = 1,
                Description = "Synth Pop"
            },

            new Genre
            {
                ID = 2,
                Description = "Funk Pop"
            }

        });

        modelBuilder.Entity<SongGenre>().HasData(new SongGenre[]
        {
            new SongGenre
            {
                ID = 1,
                SongID = 1,
                GenreID = 1
            },

            new SongGenre
            {
                ID = 2,
                SongID = 2,
                GenreID = 2
            }

        });


    }
}