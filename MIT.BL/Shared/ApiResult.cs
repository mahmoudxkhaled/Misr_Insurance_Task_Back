namespace MIT.BL;

public class ApiResult
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public object? Data { get; set; }
}
public class ApiResult<T> where T : class
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }

}