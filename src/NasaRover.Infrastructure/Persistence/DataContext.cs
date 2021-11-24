using Microsoft.EntityFrameworkCore;
using NasaRover.Domain.Business.Rover;
using NasaRover.Domain.Business.Terrain;

namespace NasaRover.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<RoverEntity> Rovers { get; set; }
    public DbSet<TerrainEntity> Terrains { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoverEntity>().OwnsOne(r => r.Location);

        modelBuilder.Entity<TerrainEntity>().OwnsMany(t => t.Obstacles);

        base.OnModelCreating(modelBuilder);
    }
}