namespace MIT.DAL;

public interface IUnitOfWork
{
    ICustomerRepository CustomerRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderProductRepository OrderProductRepository { get; }
    IProductRepository ProductRepository { get; }
    Task<int> SaveChangesAsync();

}