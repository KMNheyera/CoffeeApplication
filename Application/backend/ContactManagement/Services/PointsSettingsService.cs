using CoffeeApplication.Interfaces;
using CoffeeApplication.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CoffeeApplication.Services
{
    public class PointsSettingsService : IPointsSettingsService
    {
        private readonly IMongoCollection<PointsSettings> _pointsSettings;

        public PointsSettingsService(ICoffeeApplicationStoreDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pointsSettings = database.GetCollection<PointsSettings>(settings.PointsSettingsCollectionName);
        }

        public async Task<PointsSettings> Create(PointsSettings pointsSettings)
        {
            await _pointsSettings.InsertOneAsync(pointsSettings);
            return pointsSettings;
        }

        public async Task Delete(string id)
        {
            FilterDefinition<PointsSettings> filter = Builders<PointsSettings>.Filter.Eq("Id", id);
            await _pointsSettings.DeleteOneAsync(filter);
            return;
        }

        public async Task<PointsSettings> Get()
        {
            return await _pointsSettings.Find(new BsonDocument()).FirstOrDefaultAsync();
        }

        public async Task Update(string id, PointsSettings pointsSettings)
        {
            await _pointsSettings.ReplaceOneAsync(pointsSettings => pointsSettings.Id == id, pointsSettings);
            return;
        }

    }
}
