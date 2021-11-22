namespace NasaRover.Domain.AggregatesModel.RoverAggregate;

public class Rover
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public Terrain Terrain { get; set; }
    public Location Location { get; set; } = new Location();
    public Direction Direction { get; set; } = Direction.North;

    public Rover(Guid id, Terrain terrain, string name, Location? location = null, Direction? direction = null)
    {
        Id = id;
        Name = name;
        Terrain = terrain;
        Location = location ?? new Location();
        Direction = direction ?? Direction.North;
    }

    public int Move(Movement movement)
    {
        var moves = 0;
        var location = Location;
        var direction = Direction;

        switch (movement)
        {
            case Movement.Left:
                switch (Direction)
                {
                    case Direction.North:
                        Direction = Direction.West;
                        break;
                    default:
                        Direction = Direction - 1;
                        break;
                }
                return 0;
            case Movement.Right:
                switch (Direction)
                {
                    case Direction.West:
                        Direction = Direction.North;
                        break;
                    default:
                        Direction = Direction + 1;
                        break;
                }
                return 0;
            case Movement.Forward:
                (location, moves) = Terrain.Walk(Location, Direction);
                Location = location;
                return moves;
            case Movement.Backward:
                switch (Direction)
                {
                    case Direction.North:
                        (location, moves) = Terrain.Walk(Location, Direction.South);
                        Location = location;
                        return moves;
                    case Direction.South:
                        (location, moves) = Terrain.Walk(Location, Direction.North);
                        Location = location;
                        return moves;
                    case Direction.East:
                        (location, moves) = Terrain.Walk(Location, Direction.West);
                        Location = location;
                        return moves;
                    case Direction.West:
                        (location, moves) = Terrain.Walk(Location, Direction.East);
                        Location = location;
                        return moves;
                }
                break;
        }
        return 0;
    }
}