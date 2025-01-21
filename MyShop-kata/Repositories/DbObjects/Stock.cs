using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop_kata.Repositories.DbObjects;

public class Stock
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StockId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}