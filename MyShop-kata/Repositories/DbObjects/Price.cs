using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop_kata.Repositories.DbObjects;

public class Price
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PriceId { get; set; }
    public int ProductId { get; set; }
    public decimal PriceTag { get; set; }
}