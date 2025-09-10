namespace MIT.DAL;

public class UnitOfWork : IUnitOfWork
{
    #region Fields & Propereties
    private readonly MITDbContext _context;

    public ICustomerRepository CustomerRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IOrderProductRepository OrderProductRepository { get; }
    public IProductRepository ProductRepository { get; }

    #endregion


    #region Constructors

    public UnitOfWork(
          MITDbContext context
        , ICustomerRepository customerRepository
        , IOrderRepository orderRepository
        , IOrderProductRepository orderProductRepository
        , IProductRepository productRepository
                )
    {
        _context = context;
        CustomerRepository = customerRepository;
        OrderRepository = orderRepository;
        OrderProductRepository = orderProductRepository;
        ProductRepository = productRepository;
    }
    #endregion

    #region Functions

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    #endregion

}
