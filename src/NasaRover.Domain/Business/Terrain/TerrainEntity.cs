using System.ComponentModel.DataAnnotations;
using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Business.Rover;

namespace NasaRover.Domain.Business.Terrain;

public class TerrainEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public List<Location> Obstacles { get; set; } = new List<Location>();

    public TerrainEntity() {
        Width = 99;
        Height = 99;
        Name = "";
    }

    public TerrainEntity(Guid id, string name, int width = 99, int height = 99)
    {
        Id = id;
        Name = name;
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Method used to walk in a terrain.
    /// I choosed to put this method here because a terrain could have other shapes.
    /// </summary>
    public (Location location, int moves, string message) Walk(Location location, Direction direction)
    {
        var newLocation = new Location(location.X, location.Y);
        switch (direction)
        {
            case Direction.North:
                newLocation.Y = location.Y == Height ? 0 : location.Y + 1;
                break;
            case Direction.South:
                newLocation.Y = location.Y == 0 ? Height : location.Y - 1;
                break;
            case Direction.East:
                newLocation.X = location.X == Width ? 0 : location.X + 1;
                break;
            case Direction.West:
                newLocation.X = location.X == 0 ? Width : location.X - 1;
                break;
        }

        if (Obstacles.Any(o => o.X == newLocation.X && o.Y == newLocation.Y))
            return (location, 0, "Encountered an obstacle");

        return (newLocation, 1, "Congratulations, we could move without any problems");
    }
}