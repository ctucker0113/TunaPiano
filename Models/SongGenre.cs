using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models;


public class SongGenre
{
    public int ID { get; set; }

    public int SongID { get; set; }

    public int GenreID { get; set; }

    public Genre? Genre { get; set; }
}

