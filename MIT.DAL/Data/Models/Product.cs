namespace MIT.DAL;

public class Product
{
    public int Id { get; set; }                // unique identifier
    public string Name { get; set; } = null!;  // product name
    public string? Description { get; set; }   // product description
    public double Price { get; set; }          // product price (per assignment)
    public int Stock { get; set; }             // available stock

    public ICollection<OrderProduct> OrderItems { get; set; } = new List<OrderProduct>();
}