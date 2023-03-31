using CoffeeApplication.Dto;
using CoffeeApplication.Model;

namespace CoffeeApplication.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> Get();
        Task<Product> Get(string id);
        Task<Product> Create(Product product);
        Task<User> Payment(PaymentDto cartDto);
        Task Update(string id, Product product);
        Task Delete(string id);
    }
}
