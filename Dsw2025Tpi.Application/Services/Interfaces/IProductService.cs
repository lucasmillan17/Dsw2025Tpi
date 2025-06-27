using Dsw2025Tpi.Application.Dtos;

namespace Dsw2025Tpi.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductModel.Response> CreateProductAsync(ProductModel.Request r);
        Task DisableProductByID(Guid id);
        Task<ProductModel.Response> GetProductByID(Guid id);
        Task<IEnumerable<ProductModel.Response>> GetProductsAsync();
        Task<ProductModel.Response> UpdateProductsAsync(Guid id, ProductModel.Request r);
    }
}