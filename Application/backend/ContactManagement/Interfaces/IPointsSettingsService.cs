using CoffeeApplication.Model;

namespace CoffeeApplication.Interfaces
{
    public interface IPointsSettingsService
    {
        Task<PointsSettings> Get();
        Task<PointsSettings> Create(PointsSettings user);
        Task Update(string id, PointsSettings user);
        Task Delete(string id);
    }
}
