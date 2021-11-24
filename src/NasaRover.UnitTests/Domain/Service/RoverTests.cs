using System;
using Moq;
using NasaRover.Domain.Business.Common;
using NasaRover.Domain.Business.Rover;
using NasaRover.Domain.Business.Terrain;
using NasaRover.Domain.Services;
using Xunit;

namespace NasaRover.UnitTests.Domain.Business.Rover;

public class RoverTests
{
    [Fact]
    public void Rover_To_North()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        var roverRepositoryMoq = new Mock<IRoverRepository>();
        roverRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(rover);

        var terrainRepositoryMoq = new Mock<ITerrainRepository>();
        terrainRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pluto);

        var service = new RoverService(roverRepositoryMoq.Object, terrainRepositoryMoq.Object);
        
        var move01 = service.Move(rover.Id, "F");

        Assert.Equal(0, move01.Rover.Location.X);
        Assert.Equal(1, move01.Rover.Location.Y);
        Assert.Equal("North", move01.Rover.Direction);
    }
    [Fact]
    public void Rover_To_South()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        var roverRepositoryMoq = new Mock<IRoverRepository>();
        roverRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(rover);
        
        var terrainRepositoryMoq = new Mock<ITerrainRepository>();
        terrainRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pluto);

        var service = new RoverService(roverRepositoryMoq.Object, terrainRepositoryMoq.Object);

        var move01 = service.Move(rover.Id, "R");

        Assert.Equal(0, move01.Rover.Location.X);
        Assert.Equal(0, move01.Rover.Location.Y);
        Assert.Equal("East", move01.Rover.Direction);

        var move02 = service.Move(rover.Id, "R");

        Assert.Equal(0, move02.Rover.Location.X);
        Assert.Equal(0, move02.Rover.Location.Y);
        Assert.Equal("South", move02.Rover.Direction);

        var move03 = service.Move(rover.Id, "F");

        Assert.Equal(0, move03.Rover.Location.X);
        Assert.Equal(99, move03.Rover.Location.Y);
        Assert.Equal("South", move03.Rover.Direction);
    }
    [Fact]
    public void Rover_To_East()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        var roverRepositoryMoq = new Mock<IRoverRepository>();
        roverRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(rover);
        
        var terrainRepositoryMoq = new Mock<ITerrainRepository>();
        terrainRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pluto);

        var service = new RoverService(roverRepositoryMoq.Object, terrainRepositoryMoq.Object);

        var move01 = service.Move(rover.Id, "R");

        Assert.Equal(0, move01.Rover.Location.X);
        Assert.Equal(0, move01.Rover.Location.Y);
        Assert.Equal("East", move01.Rover.Direction);

        var move02 = service.Move(rover.Id, "F");

        Assert.Equal(1, move02.Rover.Location.X);
        Assert.Equal(0, move02.Rover.Location.Y);
        Assert.Equal("East", move01.Rover.Direction);
    }
    [Fact]
    public void Rover_To_West()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        var roverRepositoryMoq = new Mock<IRoverRepository>();
        roverRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(rover);
        
        var terrainRepositoryMoq = new Mock<ITerrainRepository>();
        terrainRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pluto);

        var service = new RoverService(roverRepositoryMoq.Object, terrainRepositoryMoq.Object);

        var move01 = service.Move(rover.Id, "L");

        Assert.Equal(0, move01.Rover.Location.X);
        Assert.Equal(0, move01.Rover.Location.Y);
        Assert.Equal("West", move01.Rover.Direction);

        var move02 = service.Move(rover.Id, "F");

        Assert.Equal(99, move02.Rover.Location.X);
        Assert.Equal(0, move02.Rover.Location.Y);
        Assert.Equal("West", move02.Rover.Direction);
    }
    [Fact]
    public void Rover_To_North_Backward()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        var roverRepositoryMoq = new Mock<IRoverRepository>();
        roverRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(rover);
        
        var terrainRepositoryMoq = new Mock<ITerrainRepository>();
        terrainRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pluto);

        var service = new RoverService(roverRepositoryMoq.Object, terrainRepositoryMoq.Object);

        var move01 = service.Move(rover.Id, "B");

        Assert.Equal(0, move01.Rover.Location.X);
        Assert.Equal(99, move01.Rover.Location.Y);
        Assert.Equal("North", move01.Rover.Direction);
    }
    [Fact]
    public void Rover_To_South_Backward()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        var roverRepositoryMoq = new Mock<IRoverRepository>();
        roverRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(rover);
        
        var terrainRepositoryMoq = new Mock<ITerrainRepository>();
        terrainRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pluto);

        var service = new RoverService(roverRepositoryMoq.Object, terrainRepositoryMoq.Object);

        var move01 = service.Move(rover.Id, "R");

        Assert.Equal(0, move01.Rover.Location.X);
        Assert.Equal(0, move01.Rover.Location.Y);
        Assert.Equal("East", move01.Rover.Direction);

        var move02 = service.Move(rover.Id, "R");

        Assert.Equal(0, move02.Rover.Location.X);
        Assert.Equal(0, move02.Rover.Location.Y);
        Assert.Equal("South", move02.Rover.Direction);

        var move03 = service.Move(rover.Id, "B");

        Assert.Equal(0, move03.Rover.Location.X);
        Assert.Equal(1, move03.Rover.Location.Y);
        Assert.Equal("South", move03.Rover.Direction);
    }
    [Fact]
    public void Rover_To_East_Backward()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        var roverRepositoryMoq = new Mock<IRoverRepository>();
        roverRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(rover);
        
        var terrainRepositoryMoq = new Mock<ITerrainRepository>();
        terrainRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pluto);

        var service = new RoverService(roverRepositoryMoq.Object, terrainRepositoryMoq.Object);

        var move01 = service.Move(rover.Id, "R");

        Assert.Equal(0, move01.Rover.Location.X);
        Assert.Equal(0, move01.Rover.Location.Y);
        Assert.Equal("East", move01.Rover.Direction);

        var move02 = service.Move(rover.Id, "B");

        Assert.Equal(99, move02.Rover.Location.X);
        Assert.Equal(0, move02.Rover.Location.Y);
        Assert.Equal("East", move02.Rover.Direction);
    }
    [Fact]
    public void Rover_To_West_Backward()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        var roverRepositoryMoq = new Mock<IRoverRepository>();
        roverRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(rover);
        
        var terrainRepositoryMoq = new Mock<ITerrainRepository>();
        terrainRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pluto);

        var service = new RoverService(roverRepositoryMoq.Object, terrainRepositoryMoq.Object);

        var move01 = service.Move(rover.Id, "L");

        Assert.Equal(0, move01.Rover.Location.X);
        Assert.Equal(0, move01.Rover.Location.Y);
        Assert.Equal("West", move01.Rover.Direction);

        var move02 = service.Move(rover.Id, "B");

        Assert.Equal(1, move02.Rover.Location.X);
        Assert.Equal(0, move02.Rover.Location.Y);
        Assert.Equal("West", move02.Rover.Direction);
    }
    [Fact]
    public void Rover_Found_An_Obstacle()
    {
        var pluto = new TerrainEntity(Guid.Empty, "Pluto");
        pluto.Obstacles.Add(new Location(2,2));
        var rover = new RoverEntity(Guid.Empty, "Pluto Rover", pluto.Id);

        var roverRepositoryMoq = new Mock<IRoverRepository>();
        roverRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(rover);
        
        var terrainRepositoryMoq = new Mock<ITerrainRepository>();
        terrainRepositoryMoq.Setup(x => x.Get(It.IsAny<Guid>())).Returns(pluto);

        var service = new RoverService(roverRepositoryMoq.Object, terrainRepositoryMoq.Object);

        var move01 = service.Move(rover.Id, "F");
        Assert.True(move01.IsSuccess);
        Assert.Equal(0, move01.Rover.Location.X);
        Assert.Equal(1, move01.Rover.Location.Y);
        Assert.Equal("North", move01.Rover.Direction);

        var move02 = service.Move(rover.Id, "F");
        Assert.True(move02.IsSuccess);
        Assert.Equal(0, move02.Rover.Location.X);
        Assert.Equal(2, move02.Rover.Location.Y);
        Assert.Equal("North", move02.Rover.Direction);

        var move03 = service.Move(rover.Id, "R");
        Assert.True(move03.IsSuccess); //A turn is made, we dont walk
        Assert.Equal(0, move03.Rover.Location.X);
        Assert.Equal(2, move03.Rover.Location.Y);
        Assert.Equal("East", move03.Rover.Direction);

        var move04 = service.Move(rover.Id, "F");
        Assert.True(move04.IsSuccess);
        Assert.Equal(1, move04.Rover.Location.X);
        Assert.Equal(2, move04.Rover.Location.Y);
        Assert.Equal("East", move04.Rover.Direction);

        var move05 = service.Move(rover.Id, "F"); //An obstacle
        Assert.False(move05.IsSuccess); // Rover is blocked by an obstacle
        Assert.Equal(1, move05.Rover.Location.X);
        Assert.Equal(2, move05.Rover.Location.Y);
        Assert.Equal("East", move05.Rover.Direction);
        
        var move06 = service.Move(rover.Id, "R");
        Assert.True(move06.IsSuccess); ///A turn is made, we dont walk
        Assert.Equal(1, move06.Rover.Location.X);
        Assert.Equal(2, move06.Rover.Location.Y);
        Assert.Equal("South", move06.Rover.Direction);
        
        var move07 = service.Move(rover.Id, "F");
        Assert.True(move07.IsSuccess);
        Assert.Equal(1, move07.Rover.Location.X);
        Assert.Equal(1, move07.Rover.Location.Y);
        Assert.Equal("South", move07.Rover.Direction);
    }
}