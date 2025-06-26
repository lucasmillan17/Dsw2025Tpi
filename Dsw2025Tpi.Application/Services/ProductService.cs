using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Tpi.Application.Dtos;
using Dsw2025Tpi.Domain.Entities;
using Dsw2025Tpi.Domain.Interfaces;

namespace Dsw2025Tpi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;
        public ProductService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> CreateProductAsync(ProductModel.Request request)
        {
            var product = new Product
            {
                Sku = request.Sku,
                InternalCode = request.InternalCode,
                Name = request.Nombre,
                Description = request.Description,
                CurrentUnitPrice = request.CurrentUnitPrice,
                StockQuantity = request.StockQuantity,
                IsActive = true
            };
            return await _repository.Add(product);
        }
        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _repository.GetById<Product>(id);
        }
        async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAll<Product>();
        }

        Task<IEnumerable<Product>> IProductService.GetAllProductsAsync()
        {
            return GetAllProductsAsync();
        }
    }
}