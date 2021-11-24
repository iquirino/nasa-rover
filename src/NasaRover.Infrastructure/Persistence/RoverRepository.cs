namespace NasaRover.Infrastructure.Persistence;

using NasaRover.Domain.Business.Rover;

public class RoverRepository : IRoverRepository
{
    private readonly DataContext _dbContext;

    public RoverRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public RoverEntity? Get(Guid id)
    {
        return _dbContext.Rovers.FirstOrDefault(r => r.Id == id);
    }

    public RoverEntity? Get(string name)
    {
        return _dbContext.Rovers.FirstOrDefault(r => r.Name == name);
    }

    public IEnumerable<RoverEntity> GetAll()
    {
        return _dbContext.Rovers;
    }

    public RoverEntity Add(RoverEntity rover)
    {
        _dbContext.Rovers.Add(rover);
        _dbContext.SaveChanges();
        return rover;
    }

    public RoverEntity Update(RoverEntity rover)
    {
        _dbContext.Rovers.Update(rover);
        _dbContext.SaveChanges();
        return rover;
    }

    public bool Delete(Guid id)
    {
        var rover = _dbContext.Rovers.FirstOrDefault(r => r.Id == id);

        if (rover == null)
            return false;

        _dbContext.Rovers.Remove(rover);
        _dbContext.SaveChanges();
        return true;
    }
}