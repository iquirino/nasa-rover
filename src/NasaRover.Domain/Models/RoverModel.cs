using NasaRover.Domain.Business.Common;

namespace NasaRover.Domain.Models;

/// <summary>
/// Model for rover.
/// </summary>
public class RoverModel
{
    /// <summary>
    /// Rover Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Rover Name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Rover's current position
    /// </summary>
    public Location Location { get; set; } = new Location();
    /// <summary>
    /// Rover's current direction
    /// </summary>
    public string Direction { get; set; }

    /// <summary>
    /// Initialize a rover
    /// </summary>
    public RoverModel(Guid id, string name, Location? location = null, Direction direction = Business.Common.Direction.North)
    {
        Id = id;
        Name = name;
        Location = location == null ? new Location() : location;
        Direction = direction.ToString();
    }
}