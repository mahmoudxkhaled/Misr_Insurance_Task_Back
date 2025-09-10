using Microsoft.EntityFrameworkCore;
using MIT.DAL;

namespace MIT.API;

public static class DatabaseSeeder
{
    public static void Seed(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MITDbContext>();

        db.Database.Migrate();

        if (!db.Customer.Any())
        {
            db.Customer.AddRange(
                new Customer { Name = "Ahmed", Email = "ahmed@gmail.com", Phone = "01117656988" },
                new Customer { Name = "Sara", Email = "sara@gmail.com", Phone = "01115666984" }
            );
        }

        if (!db.Product.Any())
        {
            db.Product.AddRange(
                new Product { Name = "Laptop", Description = "14 inch ultrabook", Price = 1200, Stock = 15 },
                new Product { Name = "Smartphone", Description = "128GB, 5G", Price = 800, Stock = 30 },
                new Product { Name = "Headphones", Description = "Noise-cancelling", Price = 150, Stock = 50 }
            );
        }

        if (db.ChangeTracker.HasChanges())
        {
            db.SaveChanges();
        }
    }
}


