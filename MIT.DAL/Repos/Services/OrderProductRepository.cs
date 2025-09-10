namespace MIT.DAL;

public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
{

    #region Fileds & Properities

    private readonly MITDbContext _context;

    #endregion

    #region Construcors

    public OrderProductRepository(MITDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Functions


    #endregion




}
