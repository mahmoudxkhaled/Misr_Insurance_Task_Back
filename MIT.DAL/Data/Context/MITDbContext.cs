using Microsoft.EntityFrameworkCore;

namespace MIT.DAL;

public class MITDbContext : DbContext
{
    public MITDbContext(DbContextOptions<MITDbContext> options) : base(options) { }

    public DbSet<Product> Product => Set<Product>();
    public DbSet<Customer> Customer => Set<Customer>();
    public DbSet<Order> Order => Set<Order>();
    public DbSet<OrderProduct> OrderProduct => Set<OrderProduct>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Customer
        modelBuilder.Entity<Customer>(b =>
        {
            b.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(200);

            b.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(320);

            b.HasIndex(x => x.Email).IsUnique();
        });

        // Product
        modelBuilder.Entity<Product>(b =>
        {
            b.Property(x => x.Name)
             .IsRequired()
             .HasMaxLength(200);

            b.Property(x => x.Price).IsRequired();
            b.Property(x => x.Stock).IsRequired();
        });

        // Order
        modelBuilder.Entity<Order>(b =>
        {
            b.Property(x => x.OrderDate).IsRequired();

            b.Property(x => x.TotalPrice).IsRequired();

            b.HasOne(o => o.Customer)
             .WithMany(c => c.Orders)
             .HasForeignKey(o => o.CustomerId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        //order product
        modelBuilder.Entity<OrderProduct>(b =>
        {
            b.HasOne(oi => oi.Order)
             .WithMany(o => o.Items)
             .HasForeignKey(oi => oi.OrderId);

            b.HasOne(oi => oi.Product)
             .WithMany(p => p.OrderItems)
             .HasForeignKey(oi => oi.ProductId);
        });

    }
}
