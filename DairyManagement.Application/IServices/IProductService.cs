

using DairyManagement.Application.DTOs;
using DairyManagement.Infrastructure;

namespace DairyManagement.Application.IServices
{
    public interface IProductService
    {
        // Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(long id);
        // Task AddProductAsync(Product product);
        // Task UpdateProductAsync(Product product);
        // Task DeleteProductAsync(Guid id);
    }
}