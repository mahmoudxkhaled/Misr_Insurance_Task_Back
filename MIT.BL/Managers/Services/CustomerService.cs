using MIT.DAL;

namespace MIT.BL;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }
    public async Task<ApiResult<List<GetCustomerDto>>> GetAllAsync()
    {
        try
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var data = customers.Select(c => new GetCustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            }).ToList();

            return new ApiResult<List<GetCustomerDto>> { IsSuccess = true, Data = data };
        }
        catch (Exception ex)
        {
            return new ApiResult<List<GetCustomerDto>> { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult<GetCustomerDto>> GetByIdAsync(int id)
    {
        try
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (customer is null)
                return new ApiResult<GetCustomerDto> { IsSuccess = false, Message = $"Customer with id {id} not found" };

            return new ApiResult<GetCustomerDto>
            {
                IsSuccess = true,
                Data = new GetCustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone
                }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult<GetCustomerDto> { IsSuccess = false, Message = ex.Message };
        }
    }

    public async Task<ApiResult<GetCustomerDto>> AddAsync(AddCustomerDto request)
    {
        try
        {
            if (await _unitOfWork.CustomerRepository.ExistsByEmailAsync(request.Email))
                return new ApiResult<GetCustomerDto> { IsSuccess = false, Message = "Email already exists" };

            var entity = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone
            };
            await _unitOfWork.CustomerRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResult<GetCustomerDto>
            {
                IsSuccess = true,
                Data = new GetCustomerDto { Id = entity.Id, Name = entity.Name, Email = entity.Email, Phone = entity.Phone }
            };
        }
        catch (Exception ex)
        {
            return new ApiResult<GetCustomerDto> { IsSuccess = false, Message = ex.Message };
        }
    }
}

