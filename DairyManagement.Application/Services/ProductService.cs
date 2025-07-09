using DairyManagement.Application.Common.Interfaces;
using DairyManagement.Application.DTOs;
using DairyManagement.Application.IServices;
using DairyManagement.Infrastructure;

namespace DairyManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product> GetProductByIdAsync(long id)
        {
            var productDetails = await _repository.GetByIdAsync(id);
            return productDetails;
        }
    }
}