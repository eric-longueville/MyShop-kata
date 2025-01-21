using MyShop_kata.DTOs;
using MyShop_kata.Repositories.DbObjects;
using MyShop_kata.Services.Interfaces;

namespace MyShop_kata.Services.Implementations;
public class OffersService : IOffersService
{
    private readonly IMyShopRepository _repository;
    public OffersService(IMyShopRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OfferDTO>> GetAllOffers()
    {
        var products = await _repository.GetAllProducts();

        return products.Select(p => new OfferDTO
        (
            productId: p.ProductId,
            productName: p.ProductName,
            productBrand: p.ProductBrand,
            productSize: p.ProductSize,
            quantity: p.Quantity.Quantity,
            price: p.Price.PriceTag
        ));
    }

    public async Task AddOffer(OfferDTO offer)
    {
        var stock = new Stock
        {
            Quantity = offer.Quantity
        };
        var price = new Price
        {
            PriceTag = offer.Price
        };
        var product = new Product
        {
            ProductName = offer.ProductName,
            ProductBrand = offer.ProductBrand,
            ProductSize = offer.ProductSize,
            Quantity = stock,
            Price = price
        };
        product = await _repository.AddProduct(product);
    }

    public async Task UpdateOffer(OfferDTO offer)
    {
        var product = await _repository.GetProductById(offer.ProductId);
        if (product == null)
        {
            return;
        }
        product.ProductName = offer.ProductName;
        product.ProductBrand = offer.ProductBrand;
        product.ProductSize = offer.ProductSize;
        if (product.Price != null)
        {
            product.Price.PriceTag = offer.Price;
        }
        if (product.Quantity != null)
        {
            product.Quantity.Quantity = offer.Quantity;
        }
        await _repository.UpdateProduct(product);
    }

    /// <summary>
    /// Sum up the offer, this is purely for the sake of having basic tests to showcase.
    /// </summary>
    /// <param name="offer">The offer to sum up.</param>
    /// <returns>v</returns>
    public string SumUpOffer(OfferDTO offer)
    {
        return $"Name: {offer.ProductName}\nBrand: {offer.ProductBrand}\nSize: {offer.ProductSize}\nPrice: {offer.Price}\nAvailability: {offer.Quantity}";
    }

    /// <summary>
    /// Sum up the product, this is purely for the sake of having basic tests to showcase.
    /// </summary>
    /// <param name="product">The product to sum up.</param>
    /// <returns>A summary of a given product.</returns>
    public string SumUpProduct(Product product)
    {
        return $"Name: {product.ProductName}\nBrand: {product.ProductBrand}\nSize: {product.ProductSize}\nPrice: {product.Price.PriceTag}\nAvailability: {product.Quantity.Quantity}";
    }
}