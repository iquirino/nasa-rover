namespace NasaRover.Domain.AggregatesModel.RoverAggregate;

public class Terrain
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    private readonly List<Location> _obstacles = new List<Location>();
    public IReadOnlyCollection<Location> Obstacles => _obstacles;

    public Terrain(Guid id, string name, int width = 99, int height = 99)
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
    public (Location Location, int Moves) Walk(Location location, Direction direction)
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

        if(Obstacles.Any(o => o.X == newLocation.X && o.Y == newLocation.Y))
            return (location, 0);

        return (newLocation, 1);
    }

    public void AddObstacle(Location location)
    {
        _obstacles.Add(location);
    }

    /// <summary>
    /// This is not needed by the exercise, but, why not remove an obstacle? :P
    /// </summary>
    public void RemoveObstacle(Location location)
    {
        _obstacles.Remove(location);
    }

    /// <summary>
    /// And what about remove all obstacles? =D
    /// </summary>
    public void RemoveAllObstacles(Location location)
    {
        _obstacles.Remove(location);
    }
}