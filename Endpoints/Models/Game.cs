using Gamestore.Models;

namespace GameStore.models;

public class Game
{
    public int id { get; set; }

    public required string Name { get; set; }
    
    public Genre? Genre {get; set; }

    public int GenreId {get; set; }

    public decimal Pice {get; set; }

    public DateOnly Releasedate {get; set;}
} 