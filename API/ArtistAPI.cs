using TunaPiano.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace TunaPiano.API
{
    public static class ArtistAPI
    {
        public static void Map(WebApplication app)
        {
            //GET All Artists
            app.MapGet("/api/artists", (TunaPianoDbContext db) =>
            {
                return db.Artists.ToList();
            });

            // GET a Single Artist and Their Song Details
            app.MapGet("/api/artists/{id}", async (int id, TunaPianoDbContext db) =>
            {
                // Pull in the Artists Database
                var artistWithSongs = await db.Artists
                // Find the Artist that matches the parameter ID
                    .Where(a => a.ID == id)
                    // "Spread" the data with the pre-existing elements by adding SongCount and Songs data
                    .Select(a => new
                    {
                        ID = a.ID,
                        Name = a.Name,
                        Age = a.Age,
                        Bio = a.Bio,
                        SongCount = db.Songs.Count(s => s.ArtistID == a.ID),
                        Songs = db.Songs
                        // Find all the songs in the songs database with the corresponding ArtistID and return their details.
                                  .Where(s => s.ArtistID == a.ID)
                                  .Select(s => new
                                  {
                                      ID = s.ID,
                                      Title = s.Title,
                                      Album = s.Album,
                                      Length = s.Length
                                  }).ToList()
                    })
                    .FirstOrDefaultAsync();

                if (artistWithSongs == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(artistWithSongs);
            });



            // CREATE an Artist
            app.MapPost("/api/artists", (TunaPianoDbContext db, Artist newArtist) =>
            {
                db.Artists.Add(newArtist);
                db.SaveChanges();
                return Results.Created($"/api/artists/{newArtist.ID}", newArtist);
            });

            // DELETE an Artist
            app.MapDelete("/api/artists/{id}", (TunaPianoDbContext db, int id) =>
            {
                Artist artistToDelete = db.Artists.SingleOrDefault(artistToDelete => artistToDelete.ID == id);
                if (artistToDelete == null)
                {
                    return Results.NotFound("Artist Not Found.");
                }
                db.Artists.Remove(artistToDelete);
                db.SaveChanges();
                return Results.NoContent();
            });

            // UPDATE an Artist
            app.MapPut("/api/artists/{id}", (TunaPianoDbContext db, int id, Artist artist) =>
            {
                Artist artistToUpdate = db.Artists.SingleOrDefault(artist => artist.ID == id);

                if (artistToUpdate == null)
                {
                    return Results.NotFound("Artist Not Found.");
                }

                artistToUpdate.Name = artist.Name;
                artistToUpdate.Age = artist.Age;
                artistToUpdate.Bio = artist.Bio;

                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}

