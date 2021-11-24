using Microsoft.AspNetCore.Mvc;
using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Models;
using NasaRover.Domain.Services;

namespace NasaRover.API.Controllers;

/// <summary>
/// Manage the Terrain
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TerrainController : ControllerBase
{
    private readonly ILogger<TerrainController> _logger;
    private readonly TerrainService _terrainService;

    /// <summary>
    /// Manage the Terrain
    /// </summary>
    public TerrainController(ILogger<TerrainController> logger, TerrainService terrainService)
    {
        _logger = logger;
        _terrainService = terrainService;
    }

    /// <summary>
    /// Create a terrain
    /// </summary>
    /// <param name="name">The rover Name</param>
    /// <param name="width">The terrain width</param>
    /// <param name="height">The terrain height</param>
    [HttpPost]
    public Guid Create(string name, int width, int height)
    {
        return _terrainService.Create(name, width, height);
    }

    /// <summary>
    /// Get a terrain
    /// </summary>
    [HttpGet]
    public IEnumerable<TerrainModel> Get()
    {
        return _terrainService.GetAll();
    }

    /// <summary>
    /// Get a terrain by its Id
    /// </summary>
    /// <param name="id">The terrain id</param>
    [HttpGet("{id}")]
    public TerrainModel? Get(Guid id)
    {
        return _terrainService.Get(id);
    }

    /// <summary>
    /// Get a terrain by its Name
    /// </summary>
    /// <param name="name">The terrain name</param>
    [HttpGet("ByName/{name}")]
    public TerrainModel? Get(string name)
    {
        return _terrainService.Get(name);
    }

    /// <summary>
    /// Add an obstacle to the terrain
    /// <para>It does nothing if it already exists</para>
    /// </summary>
    /// <param name="id">The terrain id</param>
    /// <param name="x">The obstacle location x on the terrain</param>
    /// <param name="y">The obstacle location y on the terrain</param>
    [HttpPost("{id}/Obstacle")]
    public void AddObstacle(Guid id, int x, int y)
    {
        _terrainService.AddObstacle(id, x, y);
    }

    /// <summary>
    /// Add obstacles to the terrain
    /// <para>It does nothing if it already exists</para>
    /// </summary>
    /// <param name="id">The terrain id</param>
    /// <param name="obstacles">The obstacle location on the terrain</param>
    [HttpPost("{id}/Obstacles")]
    public void AddObstacles(Guid id, [FromBody] IEnumerable<Location> obstacles)
    {
        _terrainService.AddObstacles(id, obstacles);
    }

    /// <summary>
    /// Remove an obstacle from the terrain
    /// <para>It does nothing if it already exists</para>
    /// </summary>
    /// <param name="id">The terrain id</param>
    /// <param name="x">The obstacle location x on the terrain</param>
    /// <param name="y">The obstacle location y on the terrain</param>
    [HttpDelete("{id}/Obstacle")]
    public void DeleteObstacle(Guid id, int x, int y)
    {
        _terrainService.RemoveObstacle(id, x, y);
    }

    /// <summary>
    /// Remove all obstacles from the terrain
    /// </summary>
    [HttpDelete("{id}/AllObstacles")]
    public void DeleteAllObstacle(Guid id)
    {
        _terrainService.RemoveAllObstacles(id);
    }

    /// <summary>
    /// Delete a terrain by its Id
    /// </summary>
    /// <param name="id">The terrain id</param>
    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
        _terrainService.Delete(id);
    }

    /// <summary>
    /// Update a terrain by its Id
    /// </summary>
    /// <param name="id">The terrain id</param>
    /// <param name="name">The rover Name</param>
    /// <param name="width">The terrain width</param>
    /// <param name="height">The terrain height</param>
    [HttpPut("{id}")]
    public void Update(Guid id, string name, int width, int height)
    {
        _terrainService.Update(id, name, width, height);
    }
}