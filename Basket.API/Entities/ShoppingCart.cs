namespace Basket.API.Entities;

public class ShoppingCart
{
    public string UserName { get; set; }

    public List<ShoppingCartItem> Items { get; set; } = new();
    
    public ShoppingCart() {}

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }

    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in Items)
            {
                totalPrice += item.Price * item.Quantity;
            }
            return totalPrice;
        }
    }
}