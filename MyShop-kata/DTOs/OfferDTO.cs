namespace MyShop_kata.DTOs;
public class OfferDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductBrand { get; set; }
    public string ProductSize { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public OfferDTO(int productId, string productName, string productBrand, string productSize, int quantity, decimal price)
    {
        ProductId = productId;
        ProductName = productName;
        ProductBrand = productBrand;
        ProductSize = productSize;
        Quantity = quantity;
        Price = price;
    }
}