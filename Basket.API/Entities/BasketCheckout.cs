namespace Basket.API.Entities;

public class BasketCheckout
{
    public string UserName { get; set; }
    public decimal TotalPrice { get; set; }
    
    //Billing address
    public string FirstName { get; set; }
    public string LastName { get; set; }    
    public string Email { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    
    //Payment
    public string CardNumber { get; set; }
    public string CardName { get; set; }
    public string Expiration { get; set; }
    public string CVV { get; set; }
    public int PaymentMethod { get; set; }
}