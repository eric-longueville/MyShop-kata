using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop_kata.Repositories.DbObjects;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductBrand { get; set; }
    public string ProductSize { get; set; }
    public Stock Quantity { get; set; }
    public Price Price { get; set; }
}
