using NasaRover.Domain.Business.Common;

namespace NasaRover.Domain.Models;
public class TerrainModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public List<Location> Obstacles { get; set; }

    public TerrainModel(Guid id, string name, int width = 99, int height = 99, List<Location>? obstacles = null)
    {
        Id = id;
        Name = name;
        Width = width;
        Height = height;
        Obstacles = obstacles ?? new List<Location>();
    }
}