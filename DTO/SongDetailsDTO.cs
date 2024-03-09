using System.ComponentModel.DataAnnotations;

namespace TunaPiano.DTO;

public class SongDetailsDTO
{
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Album { get; set; }
    public int? Length { get; set; }

    // Artist Details
    public string? ArtistName { get; set; }
    public int ArtistAge { get; set; }
    public string? ArtistBio { get; set; }

    // Genres
    public List<string>? Genres { get; set; }
}
