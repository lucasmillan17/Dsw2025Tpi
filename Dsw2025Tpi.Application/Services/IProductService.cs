using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dsw2025Tpi.Application.Dtos;
using System.Threading.Tasks;
using Dsw2025Tpi.Domain.Entities;

namespace Dsw2025Tpi.Application.Services
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(ProductModel.Request request);
        Task<Product> GetProductByIdAsync(Guid id);
    }
}
