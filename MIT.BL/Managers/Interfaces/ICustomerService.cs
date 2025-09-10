namespace MIT.BL;

public interface ICustomerService
{

    Task<ApiResult<List<GetCustomerDto>>> GetAllAsync();
    Task<ApiResult<GetCustomerDto>> GetByIdAsync(int id);
    Task<ApiResult<GetCustomerDto>> AddAsync(AddCustomerDto request);


}
