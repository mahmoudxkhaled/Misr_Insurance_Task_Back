namespace MIT.BL;

public class GetOrderDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int NumberOfProducts { get; set; }
}


