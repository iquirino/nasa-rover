using System;
using NasaRover.Domain.Business.Rover;
using Xunit;

namespace NasaRover.Domain.Tests.AggregatesModel.RoverAggregate;

public class RoverObstaclesTests
{
    [Fact]
    public void Rover_Found_An_Obstacle()
    {
        var moves = 0;
        var pluto = new Terrain(Guid.Empty, "Pluto");
        pluto.AddObstacle(new Location(2,2));

        var rover = new Rover(Guid.Empty, pluto, "Pluto Rover");

        moves = rover.Move(Movement.Forward);
        Assert.Equal(1, moves);

        moves = rover.Move(Movement.Forward);
        Assert.Equal(1, moves);

        Assert.Equal(0, rover.Location.X);
        Assert.Equal(2, rover.Location.Y);

        Assert.Equal(Direction.North, rover.Direction);

        moves = rover.Move(Movement.Right);
        Assert.Equal(0, moves); //A turn is made, we dont walk

        moves = rover.Move(Movement.Forward);
        Assert.Equal(1, moves);

        moves = rover.Move(Movement.Forward); //An obstacle
        Assert.Equal(0, moves); // Rover is blocked by an obstacle

        Assert.Equal(1, rover.Location.X);
        Assert.Equal(2, rover.Location.Y);
        Assert.Equal(Direction.East, rover.Direction);
    }
}