namespace Model;

public class OrderFood
{
    public int FoodId { get; set; }  // Matches JSON 'foodId'
    public string Name { get; set; }  // Matches JSON 'name'
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }  // Matches JSON 'totalPrice'; removed calculation
}