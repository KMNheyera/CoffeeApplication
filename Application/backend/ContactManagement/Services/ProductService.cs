using CoffeeApplication.Dto;
using CoffeeApplication.Interfaces;
using CoffeeApplication.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CoffeeApplication.Services
{
    public class ProductService: IProductService
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IUserService _userService;
        private readonly IPointsSettingsService _pointsSettingsService;

        public ProductService(ICoffeeApplicationStoreDatabaseSetting settings, IUserService userService, IPointsSettingsService pointsSettingsService)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductCollectionName);
            _userService = userService;
            _pointsSettingsService = pointsSettingsService;
        }

        public async Task<Product> Create(Product product)
        {
            await _products.InsertOneAsync(product);
            return product;
        }

        public async Task Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq("Id", id);
            await _products.DeleteOneAsync(filter);
            return;
        }

        public async Task<List<Product>> Get()
        {
            return await _products.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Product> Get(string id)
        {
            return await _products.Find(product => product.Id == id).FirstOrDefaultAsync();
        }


        public async Task Update(string id, Product product)
        {
            await _products.ReplaceOneAsync(product => product.Id == id, product);
            return;
        }
        public async Task<User> Payment(PaymentDto payment)
        {
            int totalQty = CalculateTotalQty(payment);
            User user = await _userService.Get(payment.UserId);
            PointsSettings pointsSettings = await _pointsSettingsService.Get();

            user.CoffeesBought += totalQty;
            
            if (user.CoffeesBought >= pointsSettings.PointsCap)
            {
                user.PointsEarned += 1 * (user.CoffeesBought / pointsSettings.PointsCap);
                user.CoffeesBought = user.CoffeesBought % pointsSettings.PointsCap;
            }

            await _userService.Update(user.Id, user);

            return user;
        }

        private int CalculateTotalQty(PaymentDto payment)
        {
            int totalQty = 0;
            foreach (var product in payment.Products)
            {
                totalQty += product.Qty;
            }
            return totalQty;
        }
    }
}
