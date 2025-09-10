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


    #endregion




}
