using Microsoft.AspNetCore.Mvc;
using NasaRover.Domain.Models;
using NasaRover.Domain.Services;

namespace NasaRover.API.Controllers;

/// <summary>
/// Manage the rover
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class RoverController : ControllerBase
{
    private readonly ILogger<RoverController> _logger;
    private readonly RoverService _roverService;

    /// <summary>
    /// Manage the rover
    /// </summary>
    public RoverController(ILogger<RoverController> logger, RoverService roverService)
    {
        _logger = logger;
        _roverService = roverService;
    }

    /// <summary>
    /// Create a rover
    /// </summary>
    /// <param name="name">The rover Name</param>
    /// <param name="terrainId">The terrain id</param>
    [HttpPost]
    public Guid Create(string name, Guid terrainId)
    {
        return _roverService.Create(name, terrainId);
    }

    /// <summary>
    /// Get all rovers
    /// </summary>
    [HttpGet]
    public IEnumerable<RoverModel> Get()
    {
        return _roverService.GetAll();
    }

    /// <summary>
    /// Get a rover by its Id
    /// </summary>
    /// <param name="id">The rover Id</param>
    [HttpGet("{id}")]
    public RoverModel? Get(Guid id)
    {
        var rover = _roverService.Get(id);
        if (rover == null)
        {
            return null;
        }
        return rover;
    }

    /// <summary>
    /// Get a rover by its name
    /// </summary>
    /// <param name="name">The rover name</param>
    [HttpGet("ByName/{name}")]
    public RoverModel? Get(string name)
    {
        var rover = _roverService.Get(name);
        if (rover == null)
        {
            return null;
        }
        return rover;
    }

    /// <summary>
    /// Move a rover
    /// </summary>
    /// <param name="id">The rover Id</param>
    /// <param name="command">
    /// The command to execute
    /// <list type="bullet">
    /// <item>
    /// <description>"F" to move Forward</description>
    /// </item>
    /// <item>
    /// <description>"B" to move Backward</description>
    /// </item>
    /// <item>
    /// <description>"L" to turn Left</description>
    /// </item>
    /// <item>
    /// <description>"R" to turn Right</description>
    /// </item>
    /// </list>
    /// </param>
    [HttpPut("Move/{id}")]
    public RoverMoveResult Move(Guid id, string command)
    {
        return _roverService.Move(id, command);
    }

    /// <summary>
    /// Delete a rover
    /// </summary>
    /// <param name="id">The rover Id</param>
    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
        _roverService.Delete(id);
    }

    /// <summary>
    /// Update a rover
    /// </summary>
    /// <param name="id">The rover Id</param>
    /// <param name="name">The rover Name</param>
    [HttpPut("{id}")]
    public void Update(Guid id, string name)
    {
        _roverService.Update(id, name);
    }
}
