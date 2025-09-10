using Microsoft.EntityFrameworkCore;

namespace MIT.DAL;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{

    #region Fileds & Properities

    private readonly MITDbContext _context;

    #endregion

    #region Construcors

    public CustomerRepository(MITDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Functions

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Customer
            .AsNoTracking()
            .AnyAsync(c => c.Email == email);
    }
    #endregion




}
