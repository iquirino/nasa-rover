using System.Collections.ObjectModel;
using System.Collections.Generic;
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

    private List<Location> _obstacles = new List<Location>();
    public IReadOnlyList<Location> Obstacles => _obstacles.AsReadOnly();

    public TerrainEntity() {
        Width = 99;
        Height = 99;
        Name = "";
    }

    public TerrainEntity(Guid id, string name, int width = 99, int height = 99)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        if (width < 1)
            throw new ArgumentOutOfRangeException(nameof(width));

        if (height < 1)
            throw new ArgumentOutOfRangeException(nameof(height));

        Id = id;
        Name = name;
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Method used to walk in a terrain.
    /// I decided to put this method here because a terrain could have other shapes.
    /// </summary>
    public (Location location, int moves, string message) Walk(Location location, Direction direction)
    {
        if(location.X < 0 || location.X > Width)
            return (location, 0, "Out of bounds");
        
        if(location.Y < 0 || location.Y > Height)
            return (location, 0, "Out of bounds");

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
            return (location, 0, "We could not move, there is an obstacle");

        return (newLocation, 1, "Congratulations, we could move without any problems");
    }

    public void AddObstacle(Location location)
    {
        if (Obstacles.Any(o => o.X == location.X && o.Y == location.Y))
            return; //Obstacle already exists
        _obstacles.Add(location);
    }

    public void RemoveObstacle(Location location)
    {
        var obstacle = _obstacles.FindIndex(o => o.X == location.X && o.Y == location.Y);
        if (obstacle >= 0)
            _obstacles.RemoveAt(obstacle);
    }

    public void RemoveAllObstacles()
    {
        _obstacles.Clear();
    }

    public void AddObstacles(IEnumerable<Location> locations)
    {
        if (locations == null)
            return;
        _obstacles.AddRange(locations.Where(l => !Obstacles.Any(o => o.X == l.X && o.Y == l.Y)));
    }
}