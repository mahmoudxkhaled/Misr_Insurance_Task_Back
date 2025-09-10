using Microsoft.EntityFrameworkCore;

namespace MIT.DAL;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{

    #region Fileds & Properities

    private readonly MITDbContext _context;

    #endregion

    #region Construcors

    public OrderRepository(MITDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Functions

    public async Task<Order?> GetOrderByIdWithProductsAsync(int id)
    {
        return await _context.Order
            .Include(o => o.Customer)
            .Include(o => o.Items)
                .ThenInclude(op => op.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
    #endregion




}
