using System.ComponentModel.DataAnnotations;
using NasaRover.Domain.Business.Common;

namespace NasaRover.Domain.Business.Rover;

public class RoverEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Location Location { get; set; } = new Location();
    public Direction Direction { get; set; } = Direction.North;

    public Guid TerrainId { get; set; }
    
    public RoverEntity()
    {
    }

    public RoverEntity(Guid id, string name, Guid terrainId, Location? location = null, Direction? direction = null)
    {
        Id = id;
        TerrainId = terrainId;
        Name = name;
        Location = location ?? new Location();
        Direction = direction ?? Direction.North;
    }
}