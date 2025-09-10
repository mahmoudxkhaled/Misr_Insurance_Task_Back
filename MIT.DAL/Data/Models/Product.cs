namespace MIT.DAL;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public ICollection<OrderProduct> OrderItems { get; set; } = new List<OrderProduct>();
}