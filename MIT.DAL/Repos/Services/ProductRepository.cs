using Microsoft.EntityFrameworkCore;

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

    public Task<List<Product>> GetByIdsAsync(IEnumerable<int> ids)
    {

        return _context.Product.AsNoTracking()
                               .Where(p => ids.Contains(p.Id))
                               .ToListAsync();
    }

    #endregion




}
