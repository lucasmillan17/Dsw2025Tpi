using Dsw2025Tpi.Application.Dtos;

namespace Dsw2025Tpi.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductModel.Response> CreateProductAsync(ProductModel.Request r);
        Task DisableProductById(Guid id);
        Task<ProductModel.Response> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductModel.Response>> GetAllProductsAsync();
        Task<ProductModel.Response> UpdateProductsAsync(Guid id, ProductModel.Request r);
    }
}