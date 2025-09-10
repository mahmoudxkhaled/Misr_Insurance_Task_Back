namespace MIT.DAL;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<bool> CustomerExistsByEmailAsync(string email);


}
