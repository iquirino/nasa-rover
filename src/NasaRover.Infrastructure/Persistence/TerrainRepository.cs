namespace NasaRover.Infrastructure.Persistence;

using NasaRover.Domain.Business.Terrain;

public class TerrainRepository : ITerrainRepository
{
    private readonly DataContext _dbContext;

    public TerrainRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TerrainEntity? Get(Guid id)
    {
        return _dbContext.Terrains.FirstOrDefault(t => t.Id == id);
    }

    public TerrainEntity? Get(string name)
    {
        return _dbContext.Terrains.FirstOrDefault(t => t.Name == name);
    }

    public IEnumerable<TerrainEntity> GetAll()
    {
        return _dbContext.Terrains;
    }

    public TerrainEntity Add(TerrainEntity terrain)
    {
        _dbContext.Terrains.Add(terrain);
        _dbContext.SaveChanges();
        return terrain;
    }

    public TerrainEntity Update(TerrainEntity terrain)
    {
        _dbContext.Terrains.Update(terrain);
        _dbContext.SaveChanges();
        return terrain;
    }

    public bool Delete(Guid id)
    {
        var terrain = _dbContext.Terrains.FirstOrDefault(t => t.Id == id);

        if (terrain == null)
            return false;

        _dbContext.Terrains.Remove(terrain);
        _dbContext.SaveChanges();
        return true;
    }
}