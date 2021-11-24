using NasaRover.Domain.Business.Terrain;

namespace NasaRover.Domain.Business.Terrain;

public interface ITerrainRepository
{
    TerrainEntity? Get(Guid id);
    TerrainEntity? Get(string name);
    IEnumerable<TerrainEntity> GetAll();
    TerrainEntity Add(TerrainEntity terrain);
    TerrainEntity Update(TerrainEntity terrain);
    bool Delete(Guid id);
}