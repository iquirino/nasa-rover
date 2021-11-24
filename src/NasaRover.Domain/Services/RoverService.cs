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


        var (success, message) = rover.Move(terrain, command);

        _roverRepository.Update(rover);
        return new RoverMoveResult(new RoverModel(rover.Id, rover.Name, rover.Location, rover.Direction), success, message);
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