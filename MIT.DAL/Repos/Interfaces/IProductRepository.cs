namespace MIT.DAL;

public interface IProductRepository : IGenericRepository<Product>
{

    Task<List<Product>> GetByIdsAsync(IEnumerable<int> ids);

}



