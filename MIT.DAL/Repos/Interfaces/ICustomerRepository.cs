namespace MIT.DAL;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<bool> ExistsByEmailAsync(string email);


}
