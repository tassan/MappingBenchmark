namespace Mapping.Models;

public class ProductStock
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double BlockedQuantity { get; set; }
    public double TotalQuantity { get; set; }
    public double AvailableQuantity => TotalQuantity - BlockedQuantity;
}