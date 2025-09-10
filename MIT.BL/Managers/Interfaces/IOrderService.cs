namespace MIT.BL;

public interface IOrderService
{

    Task<ApiResult<GetOrderDto>> AddNewOrderAsync(AddOrderDto request);
    Task<ApiResult<GetOrderDto>> GetOrderByIdAsync(int id);
    Task<ApiResult> UpdateOrderStatusAsync(int id, OrderStatus status);
}
