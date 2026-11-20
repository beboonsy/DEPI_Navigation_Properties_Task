namespace ECommerceSystem.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

    // Many Products belong to one Category
    public Category Category { get; set; } = null!;

    // Many-to-many through OrderDetail
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
