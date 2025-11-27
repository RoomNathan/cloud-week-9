namespace Model;

public class Order
{
    public string Zipcode { get; set; }
    public String Id { get; set; }  // Changed to Guid for JSON string GUID
    public List<OrderFood> OrderDetails { get; set; }  // Renamed to match JSON 'orderDetails'; changed from 'Foods'
    public decimal TotalOrderAmount { get; set; }  // Added for direct JSON mapping
    public decimal TotalPrice  // Kept as computed property if needed for logic
    {
        get
        {
            return OrderDetails?.Sum(od => od.TotalPrice) ?? 0;
        }
    }
    public DateTime OrderDate { get; set; }
    public Person CustomerDetails { get; set; }  // Renamed to match JSON 'customerDetails'
    public bool Shipped { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }  // Renamed to match JSON 'estimatedDelivery'
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}