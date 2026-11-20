namespace ECommerceSystem.Models;
public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }

    // Many Orders belong to one Customer
    public Customer Customer { get; set; } = null!;

    // Many-to-many through OrderDetail
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
