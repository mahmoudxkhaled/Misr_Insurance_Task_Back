namespace MIT.DAL;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order?> GetOrderByIdWithProductsAsync(int id);
}
