namespace NasaRover.Domain.Business.Rover;

public interface IRoverRepository
{
    RoverEntity? Get(Guid id);
    RoverEntity? Get(string name);
    IEnumerable<RoverEntity> GetAll();
    RoverEntity Add(RoverEntity rover);
    RoverEntity Update(RoverEntity rover);
    bool Delete(Guid id);
}