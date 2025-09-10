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


    #endregion




}
