using Dsw2025Tpi.Application.Dtos;

namespace Dsw2025Tpi.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModelResponse> CreateOrder(OrderModelRequest r);
        Task<OrderModelResponse> GetOrderById(Guid id);
    }
}