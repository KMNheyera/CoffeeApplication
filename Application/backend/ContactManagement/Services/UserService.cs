using CoffeeApplication.Interfaces;
using CoffeeApplication.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics.Contracts;

namespace CoffeeApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _user;
        public UserService(ICoffeeApplicationStoreDatabaseSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _user = database.GetCollection<User>(settings.UserCollectionName);
        }
        public async Task<User> Create(User user)
        {
           await _user.InsertOneAsync(user);
           return user;
        }

        public async Task Delete(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
            await _user.DeleteOneAsync(filter);
            return;
        }

        public async Task<List<User>> Get()
        {
            return await _user.Find(new BsonDocument()).ToListAsync();
        }
        
        public async Task<User> Get(string id)
        {
            return await  _user.Find(contact => contact.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User> SignIn(string email)
        {
            return await _user.Find(contact => contact.Email == email).FirstOrDefaultAsync();
        }

        public async Task Update(string id, User user)
        {
           await _user.ReplaceOneAsync(user => user.Id == id, user);
            return;
        }
    }
}
