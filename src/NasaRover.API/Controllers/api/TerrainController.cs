using Microsoft.AspNetCore.Mvc;
using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Models;
using NasaRover.Domain.Services;

namespace NasaRover.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TerrainController : ControllerBase
{
    private readonly ILogger<TerrainController> _logger;
    private readonly TerrainService _terrainService;

    public TerrainController(ILogger<TerrainController> logger, TerrainService terrainService)
    {
        _logger = logger;
        _terrainService = terrainService;
    }
    
    [HttpPost]
    public Guid Create(string name, int width, int height)
    {
        return _terrainService.Create(name, width, height);
    }

    [HttpGet]
    public IEnumerable<TerrainModel> Get()
    {
        return _terrainService.GetAll();
    }

    [HttpGet("{id}")]
    public TerrainModel? Get(Guid id)
    {
        return _terrainService.Get(id);
    }

    [HttpGet("ByName/{name}")]
    public TerrainModel? Get(string name)
    {
        return _terrainService.Get(name);
    }

    [HttpPost("{id}/Obstacle")]
    public void AddObstacle(Guid id, int x, int y)
    {
        _terrainService.AddObstacle(id, x, y);
    }

    [HttpPost("{id}/Obstacles")]
    public void AddObstacles(Guid id, [FromBody] IEnumerable<Location> obstacles)
    {
        _terrainService.AddObstacles(id, obstacles);
    }

    [HttpDelete("{id}/Obstacle")]
    public void DeleteObstacle(Guid id, int x, int y)
    {
        _terrainService.RemoveObstacle(id, x, y);
    }

    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
        _terrainService.Delete(id);
    }

    [HttpPut("{id}")]
    public void Update(Guid id, string name, int width, int height)
    {
        _terrainService.Update(id, name, width, height);
    }
}