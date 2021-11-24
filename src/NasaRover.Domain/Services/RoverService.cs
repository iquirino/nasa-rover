using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Business.Rover;
using NasaRover.Domain.Business.Terrain;
using NasaRover.Domain.Models;

namespace NasaRover.Domain.Services;
public class RoverService
{
    private readonly IRoverRepository _roverRepository;
    private readonly ITerrainRepository _terrainRepository;

    public RoverService(IRoverRepository roverRepository, ITerrainRepository terrainRepository)
    {
        _roverRepository = roverRepository;
        _terrainRepository = terrainRepository;
    }

    public Guid Create(string name, Guid terrainId)
    {
        var rover = new RoverEntity(Guid.NewGuid(), name, terrainId, new Location(0, 0), Direction.North);
        _roverRepository.Add(rover);
        return rover.Id;
    }

    public RoverModel? Get(Guid id)
    {
        var rover = _roverRepository.Get(id);
        if (rover == null)
        {
            return null;
        }
        return new RoverModel(rover.Id, rover.Name, rover.Location, rover.Direction);
    }

    public RoverModel? Get(string name)
    {
        var rover = _roverRepository.Get(name);
        if (rover == null)
        {
            return null;
        }
        return new RoverModel(rover.Id, rover.Name, rover.Location, rover.Direction);
    }

    public IEnumerable<RoverModel> GetAll()
    {
        return _roverRepository.GetAll().Select(x => new RoverModel(x.Id, x.Name, x.Location, x.Direction));
    }

    public RoverMoveResult Move(Guid id, string command)
    {
        var rover = _roverRepository.Get(id);

        if (rover == null)
            throw new Exception($"Rover with id {id} not found");

        var terrain = _terrainRepository.Get(rover.TerrainId);
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
        _roverRepository.Update(rover);
        return new RoverMoveResult(new RoverModel(rover.Id, rover.Name, rover.Location, rover.Direction)
            , shouldMove ? moves == 1 : moves == 0, message);
    }

    public void Delete(Guid id)
    {
        _roverRepository.Delete(id);
    }

    public void Update(Guid id, string name)
    {
        var rover = _roverRepository.Get(id);
        if (rover == null)
        {
            throw new Exception($"Rover with id {id} not found");
        }
        rover.Name = name;
        _roverRepository.Update(rover);
    }
}