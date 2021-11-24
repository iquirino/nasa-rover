using NasaRover.Domain.Business.Common;

namespace NasaRover.Domain.Models;
public class RoverModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Location Location { get; set; } = new Location();
    public string Direction { get; set; }

    public RoverModel(Guid id, string name, Location? location = null, Direction direction = Business.Common.Direction.North)
    {
        Id = id;
        Name = name;
        Location = location == null ? new Location() : location;
        Direction = direction.ToString();
    }
}