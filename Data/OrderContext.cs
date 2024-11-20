using Microsoft.EntityFrameworkCore;
using OrderService.Domain;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
           : base(options)
    {
    }
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().OwnsOne(
         order => order.CustomerDetails, x =>
            {
                x.ToJson();
                x.OwnsMany(details => details.Addresses);
            });

        modelBuilder.Entity<Order>().OwnsOne(
        order => order.Customer, x =>
        {
            x.Property(c => c.Type).HasConversion<string>(v => v.ToString(), v => (CustomerType)Enum.Parse(typeof(CustomerType), v));
            x.ToJson();
        });

        modelBuilder.Entity<Order>().OwnsMany(x => x.Items);

    }
}