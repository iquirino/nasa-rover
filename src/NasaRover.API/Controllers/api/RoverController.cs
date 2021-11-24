using Microsoft.AspNetCore.Mvc;
using NasaRover.Domain.Models;
using NasaRover.Domain.Services;

namespace NasaRover.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoverController : ControllerBase
{
    private readonly ILogger<RoverController> _logger;
    private readonly RoverService _roverService;

    public RoverController(ILogger<RoverController> logger, RoverService roverService)
    {
        _logger = logger;
        _roverService = roverService;
    }
    
    [HttpPost]
    public Guid Create(string name, Guid terrainId)
    {
        return _roverService.Create(name, terrainId);
    }
    
    [HttpGet]
    public IEnumerable<RoverModel> Get()
    {
        return _roverService.GetAll();
    }

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

    [HttpPut("Move/{id}")]
    public RoverMoveResult Move(Guid id, string command)
    {
        return _roverService.Move(id, command);
    }

    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
        _roverService.Delete(id);
    }

    [HttpPut("{id}")]
    public void Update(Guid id, string name)
    {
        _roverService.Update(id, name);
    }
}
