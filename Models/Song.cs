using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models;

    public class Song
    {
        public int ID { get; set; }

        public string? Title { get; set; }

        public int? ArtistID { get; set; }

        public string? Album { get; set; }

        public int? Length { get; set; }

        public Artist? Artist { get; set; }

        public ICollection<SongGenre>? SongGenres { get; set; }

    }

