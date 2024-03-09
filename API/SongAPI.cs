using TunaPiano.Models;
using TunaPiano.DTO;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace TunaPiano.API
{
    public static class SongAPI
    {
        public static void Map(WebApplication app)
        {
            //GET All Songs
            app.MapGet("/api/songs", async (TunaPianoDbContext db) =>
            {
                return db.Songs.ToList();
            });

            //GET a Single Song and its details
            app.MapGet("/api/songs/{id}", async (int id, TunaPianoDbContext db) =>
            {
                var song = await db.Songs
                // Finds the song in the database with the corresponding songID
                    .Where(s => s.ID == id)
                // Includes the Artist data associated with the ArtistID number in the Song table
                    .Include(s => s.Artist)
                // Combines the Song/Artist object with the Genres data into a new, fused object.
                    .Select(s => new
                    {
                        Song = s,
                        Genres = db.SongGenres
                        //Finds the SongGenre ID that contains the ID # of the song.
                                  .Where(sg => sg.SongID == s.ID)
                        // Joins the genres data with the song/artist object created above.
                                  .Join(db.Genres,
                                        sg => sg.GenreID,
                                        g => g.ID,
                                        (sg, g) => g.Description)
                                  .ToList()
                    })
                    .FirstOrDefaultAsync();

                if (song == null)
                {
                    return Results.NotFound();
                }

                //Create a new DTO with all of the data we've fetched.
                var songDto = new SongDetailsDTO
                {
                    ID = song.Song.ID,
                    Title = song.Song.Title,
                    Album = song.Song.Album,
                    Length = song.Song.Length,
                    ArtistName = song.Song.Artist.Name,
                    ArtistAge = song.Song.Artist.Age,
                    ArtistBio = song.Song.Artist.Bio,
                    Genres = song.Genres
                };

                return Results.Ok(songDto);
            });

            // CREATE a Song
            app.MapPost("/api/songs", async (TunaPianoDbContext db, Song newSong) =>
            {
                db.Songs.Add(newSong);
                await db.SaveChangesAsync();

                return Results.Created($"/api/songs/{newSong.ID}", newSong);
            });

            // DELETE a Song
            app.MapDelete("/api/songs/{id}", (TunaPianoDbContext db, int id) =>
            {
                Song songToDelete = db.Songs.SingleOrDefault(songToDelete => songToDelete.ID == id);
                if (songToDelete == null)
                {
                    return Results.NotFound("Song Not Found.");
                }
                db.Songs.Remove(songToDelete);
                db.SaveChanges();
                return Results.NoContent();
            });

            // UPDATE a Song
            app.MapPut("/api/songs/{id}", (TunaPianoDbContext db, int id, Song song) =>
            {
                Song songToUpdate = db.Songs.SingleOrDefault(song => song.ID == id);
                if (songToUpdate == null)
                {
                    return Results.NotFound("Song Not Found.");
                }
                songToUpdate.Title = song.Title;
                songToUpdate.ArtistID = song.ArtistID;
                songToUpdate.Album = song.Album;
                songToUpdate.Length = song.Length;

                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}

