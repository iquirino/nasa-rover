using NasaRover.Domain.Business.Common;

namespace NasaRover.Domain.Models;
public class TerrainModel
{
    /// <summary>
    /// Terrain Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Terrain Name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Terrain Width
    /// </summary>
    public int Width { get; set; }
    /// <summary>
    /// Terrain Height
    /// </summary>
    public int Height { get; set; }
    /// <summary>
    /// List of Obstacle positions
    /// </summary>
    public IEnumerable<Location> Obstacles { get; set; }

    /// <summary>
    /// Initialize Terrain
    /// </summary>
    public TerrainModel(Guid id, string name, int width = 99, int height = 99, IEnumerable<Location>? obstacles = null)
    {
        Id = id;
        Name = name;
        Width = width;
        Height = height;
        Obstacles = obstacles ?? new List<Location>();
    }
}