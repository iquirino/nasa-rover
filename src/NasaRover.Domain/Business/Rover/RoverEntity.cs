using System.ComponentModel.DataAnnotations;
using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Business.Terrain;

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
    
    public (bool success, string message) Move(TerrainEntity terrain, string command)
    {
        var rover = this;

        if (terrain == null)
            throw new Exception($"Terrain with id {rover.TerrainId} not found");

        Movement movement;

        switch (command.ToUpper())
        {
            case "L":
                movement = Movement.Left;
                break;
            case "R":
                movement = Movement.Right;
                break;
            case "F":
                movement = Movement.Forward;
                break;
            case "B":
                movement = Movement.Backward;
                break;
            default:
                throw new ArgumentException("Invalid movement");
        }

        var shouldMove = false;
        var moves = 0;
        var location = rover.Location;
        var message = string.Empty;
        var direction = rover.Direction;

        switch (movement)
        {
            case Movement.Left:
                switch (rover.Direction)
                {
                    case Direction.North:
                        direction = Direction.West;
                        break;
                    default:
                        direction = rover.Direction - 1;
                        break;
                }
                message = $"Turned left, from {rover.Direction} to {direction.ToString()}";
                break;
            case Movement.Right:
                switch (rover.Direction)
                {
                    case Direction.West:
                        direction = Direction.North;
                        break;
                    default:
                        direction = rover.Direction + 1;
                        break;
                }
                message = $"Turned right, from {rover.Direction} to {direction.ToString()}";
                break;
            case Movement.Forward:
                (location, moves, message) = terrain.Walk(rover.Location, rover.Direction);
                shouldMove = true;
                break;
            case Movement.Backward:
                switch (rover.Direction)
                {
                    case Direction.North:
                        (location, moves, message) = terrain.Walk(rover.Location, Direction.South);
                        break;
                    case Direction.South:
                        (location, moves, message) = terrain.Walk(rover.Location, Direction.North);
                        break;
                    case Direction.East:
                        (location, moves, message) = terrain.Walk(rover.Location, Direction.West);
                        break;
                    case Direction.West:
                        (location, moves, message) = terrain.Walk(rover.Location, Direction.East);
                        break;
                }
                shouldMove = true;
                break;
        }
        rover.Direction = direction;
        rover.Location = location;
        return (shouldMove ? moves == 1 : moves == 0, message);
    }
}