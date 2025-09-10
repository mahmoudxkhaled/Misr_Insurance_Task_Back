namespace MIT.DAL;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = null!;
    public double TotalPrice { get; set; }
    public ICollection<OrderProduct> Items { get; set; } = new List<OrderProduct>();
}
