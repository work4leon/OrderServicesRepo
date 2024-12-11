using Microsoft.EntityFrameworkCore;
using OrderService.Domain;

public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().OwnsOne(
         order => order.Customer, x =>
            {
                x.ToJson();
                x.OwnsOne(details => details.CustomerDetail);
                x.OwnsOne(x => x.CustomerDetail, x =>
                {
                    x.OwnsMany(y => y.Addresses);
                });
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