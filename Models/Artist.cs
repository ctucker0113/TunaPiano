using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models;


public class Artist
{
    public int ID { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public string? Bio { get; set; }

    public ICollection<Song>? Songs { get; set; }

}
