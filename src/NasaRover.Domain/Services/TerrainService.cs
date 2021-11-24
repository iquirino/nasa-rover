using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Business.Terrain;
using NasaRover.Domain.Models;

namespace NasaRover.Domain.Services;

public class TerrainService
{
    private ITerrainRepository _terrainRepository;

    public TerrainService(ITerrainRepository terrainRepository)
    {
        _terrainRepository = terrainRepository;
    }

    public Guid Create(string name, int width, int height)
    {
        var terrain = new TerrainEntity(Guid.NewGuid(), name, width, height);
        var ret = _terrainRepository.Add(terrain);
        return ret.Id;
    }

    public IEnumerable<TerrainModel> GetAll()
    {
        return _terrainRepository.GetAll().Select(x => new TerrainModel(x.Id, x.Name, x.Width, x.Height, x.Obstacles));
    }

    public TerrainModel? Get(string name)
    {
        var terrain = _terrainRepository.Get(name);
        if (terrain == null)
        {
            return null;
        }
        return new TerrainModel(terrain.Id, terrain.Name, terrain.Width, terrain.Height, terrain.Obstacles);
    }

    public TerrainModel? Get(Guid id)
    {
        var terrain = _terrainRepository.Get(id);
        if (terrain == null)
        {
            return null;
        }
        return new TerrainModel(terrain.Id, terrain.Name, terrain.Width, terrain.Height, terrain.Obstacles);
    }

    public void AddObstacle(Guid id, int x, int y)
    {
        var terrain = _terrainRepository.Get(id);
        if(terrain == null)
        {
            throw new Exception("Terrain not found");
        }
        terrain.Obstacles.Add(new Location(x, y));
        _terrainRepository.Update(terrain);
    }

    public void RemoveObstacle(Guid id, int x, int y)
    {
        var terrain = _terrainRepository.Get(id);
        if(terrain == null)
        {
            throw new Exception("Terrain not found");
        }
        terrain.Obstacles.RemoveAt(terrain.Obstacles.FindIndex(o => o.X == x && o.Y == y));
        _terrainRepository.Update(terrain);
    }

    public void AddObstacles(Guid id, IEnumerable<Location> obstacles)
    {
        var terrain = _terrainRepository.Get(id);
        if(terrain == null)
        {
            throw new Exception("Terrain not found");
        }
        terrain.Obstacles.AddRange(obstacles);
        _terrainRepository.Update(terrain);
    }

    public void Update(Guid id, string name, int width, int height)
    {
        var terrain = _terrainRepository.Get(id);
        if(terrain == null)
        {
            throw new Exception("Terrain not found");
        }

        terrain.Name = name;
        terrain.Width = width;
        terrain.Height = height;
        _terrainRepository.Update(terrain);
    }

    public void Delete(Guid id)
    {
        _terrainRepository.Delete(id);
    }
}
