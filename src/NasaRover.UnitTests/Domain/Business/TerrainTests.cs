using System;
using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Business.Rover;
using NasaRover.Domain.Business.Terrain;
using NasaRover.Domain.Services;
using Xunit;

namespace NasaRover.UnitTests.Domain.Business;

public class TerrainTests
{
    [Fact]
    public void Valid_Values()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        Assert.NotNull(terrain);
        Assert.Equal(5, terrain.Width);
        Assert.Equal(5, terrain.Height);
    }

    [Fact]
    public void Default_Values()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto");
        Assert.NotNull(terrain);
        Assert.Equal(99, terrain.Width);
        Assert.Equal(99, terrain.Height);
    }

    [Fact]
    public void Invalid_Width()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new TerrainEntity(Guid.Empty, "Pluto", -1, 5));
    }

    [Fact]
    public void Invalid_Height()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new TerrainEntity(Guid.Empty, "Pluto", 5, 0));
    }

    [Fact]
    public void Invalid_Width_And_Height()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new TerrainEntity(Guid.Empty, "Pluto", -1, 0));
    }

    [Fact]
    public void Invalid_Name()
    {
        Assert.Throws<ArgumentNullException>(() => new TerrainEntity(Guid.Empty, null, 5, 5));
    }

    [Fact]
    public void Walk_North_With_Succes()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        (Location location, int moves, string message) = terrain.Walk(new Location(), Direction.North);
        Assert.Equal(0, location.X);
        Assert.Equal(1, location.Y);
        Assert.Equal(1, moves);
        Assert.Equal("Congratulations, we could move without any problems", message);
    }

    [Fact]
    public void Walk_North_With_Out_Of_Bounds()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        (Location location, int moves, string message) = terrain.Walk(new Location(5, 5), Direction.North);
        Assert.Equal(5, location.X);
        Assert.Equal(0, location.Y);
        Assert.Equal(1, moves);
        Assert.Equal("Congratulations, we could move without any problems", message);
    }

    [Fact]
    public void Walk_South_With_Succes()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        (Location location, int moves, string message) = terrain.Walk(new Location(), Direction.South);
        Assert.Equal(0, location.X);
        Assert.Equal(5, location.Y);
        Assert.Equal(1, moves);
        Assert.Equal("Congratulations, we could move without any problems", message);
    }

    [Fact]
    public void Walk_South_With_Out_Of_Bounds()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        (Location location, int moves, string message) = terrain.Walk(new Location(0, 0), Direction.South);
        Assert.Equal(0, location.X);
        Assert.Equal(5, location.Y);
        Assert.Equal(1, moves);
        Assert.Equal("Congratulations, we could move without any problems", message);
    }

    [Fact]
    public void Walk_East_With_Succes()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        (Location location, int moves, string message) = terrain.Walk(new Location(), Direction.East);
        Assert.Equal(1, location.X);
        Assert.Equal(0, location.Y);
        Assert.Equal(1, moves);
        Assert.Equal("Congratulations, we could move without any problems", message);
    }

    [Fact]
    public void Walk_East_With_Out_Of_Bounds()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        (Location location, int moves, string message) = terrain.Walk(new Location(5, 5), Direction.East);
        Assert.Equal(0, location.X);
        Assert.Equal(5, location.Y);
        Assert.Equal(1, moves);
        Assert.Equal("Congratulations, we could move without any problems", message);
    }

    [Fact]
    public void Walk_West_With_Succes()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        (Location location, int moves, string message) = terrain.Walk(new Location(5, 5), Direction.West);
        Assert.Equal(4, location.X);
        Assert.Equal(5, location.Y);
        Assert.Equal(1, moves);
        Assert.Equal("Congratulations, we could move without any problems", message);
    }

    [Fact]
    public void Walk_West_With_Out_Of_Bounds()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        (Location location, int moves, string message) = terrain.Walk(new Location(0, 0), Direction.West);
        Assert.Equal(5, location.X);
        Assert.Equal(0, location.Y);
        Assert.Equal(1, moves);
        Assert.Equal("Congratulations, we could move without any problems", message);
    }

    [Fact]
    public void Walk_North_To_A_Place_Greater_Than_Terrain()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        terrain.AddObstacle(new Location(3, 3));
        (Location location, int moves, string message) = terrain.Walk(new Location(8, 8), Direction.North);
        Assert.Equal(8, location.X);
        Assert.Equal(8, location.Y);
        Assert.Equal(0, moves);
        Assert.Equal("Out of bounds", message);
    }

    [Fact]
    public void Walk_North_To_A_Place_With_Obstacle()
    {
        var terrain = new TerrainEntity(Guid.Empty, "Pluto", 5, 5);
        terrain.AddObstacle(new Location(3, 3));
        (Location location, int moves, string message) = terrain.Walk(new Location(3, 2), Direction.North);
        Assert.Equal(3, location.X);
        Assert.Equal(2, location.Y);
        Assert.Equal(0, moves);
        Assert.Equal("We could not move, there is an obstacle", message);
    }
}