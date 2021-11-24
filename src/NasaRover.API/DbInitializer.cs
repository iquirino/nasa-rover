using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Business.Rover;
using NasaRover.Domain.Business.Terrain;
using NasaRover.Infrastructure.Persistence;

namespace NasaRover.API;
public static class DbInitializer
{
    public static void Initialize(DataContext context)
    {
        if (context.Terrains.Any())
        {
            return;
        }

        var terrainId = Guid.NewGuid();
        context.Terrains.Add(new TerrainEntity
        {
            Id = terrainId,
            Name = "Pluto",
            Width = 99,
            Height = 99,
            Obstacles = new List<Location>
            {
                new Location(0, 2),
                new Location(0, 3),
                new Location(0, 5),
                new Location(0, 6),
                new Location(0, 7),
                new Location(0, 10),
                new Location(0, 11),
                new Location(0, 12),
                new Location(0, 13),
                new Location(0, 14),
                new Location(0, 17),
                new Location(0, 18),
                new Location(0, 19),
                new Location(0, 20),
                new Location(0, 21),
                new Location(0, 25),
                new Location(0, 26),
                new Location(0, 27),
                new Location(0, 28),
                new Location(0, 29),
                new Location(0, 33),
                new Location(0, 34),
                new Location(0, 35),
                new Location(0, 36),
                new Location(0, 37),
                new Location(0, 40),
                new Location(0, 41),
                new Location(0, 43),
                new Location(0, 48),
                new Location(0, 49),
                new Location(0, 53),
            }
        });

        context.Rovers.Add(new RoverEntity
        {
            Id = Guid.NewGuid(),
            Name = "Nasa Rover",
            Location = new Location(0, 0),
            Direction = Direction.North,
            TerrainId = terrainId,
        });

        context.SaveChanges();
    }
}