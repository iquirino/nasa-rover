using System;
using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Business.Rover;
using NasaRover.Domain.Business.Terrain;
using NasaRover.Domain.Services;
using Xunit;

namespace NasaRover.UnitTests.Domain.Business;

public class RoverTests
{
    [Fact]
    public void Rover_To_North()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        (bool success, string message) = rover.Move(pluto, "F");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(1, rover.Location.Y);
        Assert.Equal(Direction.North, rover.Direction);
        Assert.True(success);
    }

    [Fact]
    public void Rover_To_South()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        (bool success01, string message01) = rover.Move(pluto, "R");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        (bool success02, string message02) = rover.Move(pluto, "R");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);

        (bool success03, string message03) = rover.Move(pluto, "F");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(99, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);
    }
    [Fact]
    public void Rover_To_East()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        (bool success01, string message01) = rover.Move(pluto, "R");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        (bool success02, string message02) = rover.Move(pluto, "F");

        Assert.Equal(1, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);
    }
    [Fact]
    public void Rover_To_West()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        (bool success01, string message01) = rover.Move(pluto, "L");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.West, rover.Direction);

        (bool success02, string message02) = rover.Move(pluto, "F");

        Assert.Equal(99, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.West, rover.Direction);
    }
    [Fact]
    public void Rover_To_North_Backward()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        (bool success01, string message01) = rover.Move(pluto, "B");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(99, rover.Location.Y);
        Assert.Equal(Direction.North, rover.Direction);
    }
    [Fact]
    public void Rover_To_South_Backward()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        (bool success01, string message01) = rover.Move(pluto, "R");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        (bool success02, string message02) = rover.Move(pluto, "R");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);

        (bool success03, string message03) = rover.Move(pluto, "B");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(1, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);
    }
    [Fact]
    public void Rover_To_East_Backward()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        (bool success01, string message01) = rover.Move(pluto, "R");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        (bool success02, string message02) = rover.Move(pluto, "B");

        Assert.Equal(99, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);
    }
    [Fact]
    public void Rover_To_West_Backward()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        (bool success01, string message01) = rover.Move(pluto, "L");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.West, rover.Direction);

        (bool success02, string message02) = rover.Move(pluto, "B");

        Assert.Equal(1, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.West, rover.Direction);
    }
    [Fact]
    public void Rover_Found_An_Obstacle()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        pluto.AddObstacle(new Location(2,2));
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        (bool success01, string message01) = rover.Move(pluto, "F");
        Assert.True(success01);
        Assert.Equal(0, rover.Location.X);
        Assert.Equal(1, rover.Location.Y);
        Assert.Equal(Direction.North, rover.Direction);

        (bool success02, string message02) = rover.Move(pluto, "F");
        Assert.True(success02);
        Assert.Equal(0, rover.Location.X);
        Assert.Equal(2, rover.Location.Y);
        Assert.Equal(Direction.North, rover.Direction);

        (bool success03, string message03) = rover.Move(pluto, "R");
        Assert.True(success03); //A turn is made, we dont walk
        Assert.Equal(0, rover.Location.X);
        Assert.Equal(2, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        (bool success04, string message04) = rover.Move(pluto, "F");
        Assert.True(success04);
        Assert.Equal(1, rover.Location.X);
        Assert.Equal(2, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        (bool success05, string message05) = rover.Move(pluto, "F"); //An obstacle
        Assert.False(success05); // Rover is blocked by an obstacle
        Assert.Equal(1, rover.Location.X);
        Assert.Equal(2, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);
        
        (bool success06, string message06) = rover.Move(pluto, "R");
        Assert.True(success06); ///A turn is made, we dont walk
        Assert.Equal(1, rover.Location.X);
        Assert.Equal(2, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);
        
        (bool success07, string message07) = rover.Move(pluto, "F");
        Assert.True(success07);
        Assert.Equal(1, rover.Location.X);
        Assert.Equal(1, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);
    }
}