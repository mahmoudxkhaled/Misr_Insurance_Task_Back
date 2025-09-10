using MIT.DAL;

namespace MIT.BL;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }
    public async Task<ApiResult<GetOrderDto>> AddNewOrderAsync(AddOrderDto request)
    {
        try
        {
            if (request.CustomerId <= 0)
                return new ApiResult<GetOrderDto> { IsSuccess = false, Message = "CustomerId is required" };

            if (request.ProductIds is null || request.ProductIds.Count == 0)
                return new ApiResult<GetOrderDto> { IsSuccess = false, Message = "Order must contain at least one product" };

            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
                return new ApiResult<GetOrderDto> { IsSuccess = false, Message = $"Customer with id {request.CustomerId} not found" };

            var products = await _unitOfWork.ProductRepository.GetByIdsAsync(request.ProductIds);

            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending.ToString(),
                TotalPrice = 0
            };

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            double total = 0;
            foreach (var p in products)
            {
                await _unitOfWork.OrderProductRepository.AddAsync(new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = p.Id,
                });
                total += p.Price;
            }

            order.TotalPrice = total;
            _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResult<GetOrderDto>
            {
                IsSuccess = true,
                Data = new GetOrderDto
                {
                    Id = order.Id,
                    CustomerName = customer.Name,
                    Status = order.Status,
                    NumberOfProducts = request.ProductIds.Count
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult<GetOrderDto> { IsSuccess = false, Message = ex.Message };
        }
    }




    public async Task<ApiResult<GetOrderDto>> GetOrderByIdAsync(int id)
    {
        try
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdWithProductsAsync(id);
            if (order == null)
                return new ApiResult<GetOrderDto> { IsSuccess = false, Message = $"Order with id {id} not found" };

            var numberOfProducts = order.Items.Count;
            return new ApiResult<GetOrderDto>
            {
                IsSuccess = true,
                Data = new GetOrderDto
                {
                    Id = order.Id,
                    CustomerName = order.Customer?.Name ?? string.Empty,
                    Status = order.Status,
                    NumberOfProducts = numberOfProducts
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult<GetOrderDto> { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult> UpdateOrderStatusAsync(int id, OrderStatus status)
    {
        try
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdWithProductsAsync(id);
            if (order == null)
                return new ApiResult { IsSuccess = false, Message = $"Order with id {id} not found" };

            if (order.Status == OrderStatus.Delivered.ToString())
                return new ApiResult { IsSuccess = false, Message = "Order already delivered" };

            order.Status = status.ToString();

            if (status == OrderStatus.Delivered)
            {
                foreach (var item in order.Items)
                {
                    var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
                    if (product == null)
                        return new ApiResult { IsSuccess = false, Message = $"Product {item.ProductId} not found" };

                    if (product.Stock < 1)
                        return new ApiResult { IsSuccess = false, Message = $"Insufficient stock for product {product.Name}" };

                    product.Stock -= 1;
                }
            }

            await _unitOfWork.SaveChangesAsync();
            return new ApiResult { IsSuccess = true, Data = true };
        }
        catch (Exception ex)
        {
            return new ApiResult { IsSuccess = false, Message = ex.Message };
        }
    }
}
