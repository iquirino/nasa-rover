using System;
using NasaRover.Domain.AggregatesModel.RoverAggregate;
using Xunit;

namespace NasaRover.Domain.Tests.AggregatesModel.RoverAggregate;

public class RoverTests
{
    [Fact]
    public void Rover_Should_Be_Created_With_Valid_Data()
    {
        var pluto = new Terrain(Guid.Empty, "Pluto");
        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.North, rover.Direction);
    }
    [Fact]
    public void Rover_To_North()
    {
        var pluto = new Terrain(Guid.Empty, "Pluto");
        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        rover.Move(Movement.Forward);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(1, rover.Location.Y);
        Assert.Equal(Direction.North, rover.Direction);
    }
    [Fact]
    public void Rover_To_South()
    {
        var pluto = new Terrain(Guid.Empty, "Pluto");
        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        rover.Move(Movement.Right);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        rover.Move(Movement.Right);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);

        rover.Move(Movement.Forward);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(99, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);
    }
    [Fact]
    public void Rover_To_East()
    {
        var pluto = new Terrain(Guid.Empty, "Pluto");
        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        rover.Move(Movement.Right);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        rover.Move(Movement.Forward);

        Assert.Equal(1, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);
    }
    [Fact]
    public void Rover_To_West()
    {
        var pluto = new Terrain(Guid.Empty, "Pluto");
        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        rover.Move(Movement.Left);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.West, rover.Direction);

        rover.Move(Movement.Forward);

        Assert.Equal(99, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.West, rover.Direction);
    }
    [Fact]
    public void Rover_To_North_Backward()
    {
        var pluto = new Terrain(Guid.Empty, "Pluto");
        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        rover.Move(Movement.Backward);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(99, rover.Location.Y);
        Assert.Equal(Direction.North, rover.Direction);
    }
    [Fact]
    public void Rover_To_South_Backward()
    {
        var pluto = new Terrain(Guid.Empty, "Pluto");
        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        rover.Move(Movement.Right);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        rover.Move(Movement.Right);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);

        rover.Move(Movement.Backward);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(1, rover.Location.Y);
        Assert.Equal(Direction.South, rover.Direction);
    }
    [Fact]
    public void Rover_To_East_Backward()
    {
        var pluto = new Terrain(Guid.Empty, "Pluto");
        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        rover.Move(Movement.Right);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);

        rover.Move(Movement.Backward);

        Assert.Equal(99, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);
    }
    [Fact]
    public void Rover_To_West_Backward()
    {
        var pluto = new Terrain(Guid.Empty, "Pluto");
        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        rover.Move(Movement.Left);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.West, rover.Direction);

        rover.Move(Movement.Backward);

        Assert.Equal(1, rover.Location.X);
        Assert.Equal(0, rover.Location.Y);
        Assert.Equal(Direction.West, rover.Direction);
    }
}