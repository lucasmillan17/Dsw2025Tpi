using Dsw2025Tpi.Application.Dtos;

namespace Dsw2025Tpi.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel.Response> CreateOrder(OrderModel.Request r);
    }
}