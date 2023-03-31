using CoffeeApplication.Model;

namespace CoffeeApplication.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> Get();
        Task<User> Get(string id);
        Task<User> SignIn(string email);
        Task<User> Create(User user);
        Task Update(string id, User user);
        Task Delete(string id);
    }
}
