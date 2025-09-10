namespace MIT.DAL;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{

    #region Fileds & Properities

    private readonly MITDbContext _context;

    #endregion

    #region Construcors

    public ProductRepository(MITDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Functions


    #endregion




}
