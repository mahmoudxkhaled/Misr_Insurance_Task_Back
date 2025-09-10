namespace MIT.BL;

public class AddOrderDto
{
    public int CustomerId { get; set; }
    public List<int> ProductIds { get; set; } = new();
}
