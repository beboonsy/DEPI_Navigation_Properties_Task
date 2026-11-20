using ECommerceSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSystem.Data;
public class ECommerceContext : DbContext
{
    public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products).WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders).WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => new { od.OrderId, od.ProductId });

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails).WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderDetails).WithOne(od => od.Product)
            .HasForeignKey(od => od.ProductId);

        modelBuilder.Entity<Customer>().Property(c => c.Email).HasMaxLength(150);
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(10, 2);
    }
}
