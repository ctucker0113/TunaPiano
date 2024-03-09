using TunaPiano.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace TunaPiano.API
{
    public static class GenreAPI
    {
        public static void Map(WebApplication app)
        {
            //GET All Genres
            app.MapGet("/api/genres", (TunaPianoDbContext db) =>
            {
                return db.Genres.ToList();
            });

            // GET a Single Genre and its Extended Details

            app.MapGet("/api/genres/{id}", async (int id, TunaPianoDbContext db) =>
            {
                var genreWithSongs = await db.Genres
                    .Where(g => g.ID == id)
                    .Select(g => new
                    {
                        ID = g.ID,
                        Description = g.Description,
                        Songs = db.SongGenres
                                  .Where(sg => sg.GenreID == g.ID)
                                  .Join(db.Songs,
                                        sg => sg.SongID,
                                        s => s.ID,
                                        (sg, s) => new
                                        {
                                            ID = s.ID,
                                            Title = s.Title,
                                            ArtistID = s.ArtistID,
                                            Album = s.Album,
                                            Length = s.Length
                                        })
                                  .ToList()
                    })
                    .FirstOrDefaultAsync();

                if (genreWithSongs == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(genreWithSongs);
            });

            //app.MapGet("/api/genres/{id}", (TunaPianoDbContext db, int id) =>
            //{
            //    var genreID = db.Genres.FirstOrDefault(c => c.ID == id);

            //    if (genreID == null)
            //    {
            //        return Results.NotFound("Genre Not Found.");
            //    }

            //    return Results.Ok(genreID);
            //});

            // CREATE a Genre
            app.MapPost("/api/genres", (TunaPianoDbContext db, Genre newGenre) =>
            {
                db.Genres.Add(newGenre);
                db.SaveChanges();
                return Results.Created($"/api/genres/{newGenre.ID}", newGenre);
            });

            // DELETE a Genre
            app.MapDelete("/api/genres/{id}", (TunaPianoDbContext db, int id) =>
            {
                Genre genreToDelete = db.Genres.SingleOrDefault(genreToDelete => genreToDelete.ID == id);
                if (genreToDelete == null)
                {
                    return Results.NotFound("Genre Not Found.");
                }
                db.Genres.Remove(genreToDelete);
                db.SaveChanges();
                return Results.NoContent();
            });

            // UPDATE a Genre
            app.MapPut("/api/genres/{id}", (TunaPianoDbContext db, int id, Genre genre) =>
            {
                Genre genreToUpdate = db.Genres.SingleOrDefault(genre => genre.ID == id);
                if (genreToUpdate == null)
                {
                    return Results.NotFound("Genre Not Found.");
                }

                genreToUpdate.Description = genre.Description;

                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}