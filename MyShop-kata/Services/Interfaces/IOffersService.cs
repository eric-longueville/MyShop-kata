using MyShop_kata.DTOs;
using MyShop_kata.Repositories.DbObjects;

namespace MyShop_kata.Services.Interfaces;
public interface IOffersService
{
    public Task<IEnumerable<OfferDTO>> GetAllOffers();
    public Task AddOffer(OfferDTO offer);
    public Task UpdateOffer(OfferDTO offer);
    public string SumUpOffer(OfferDTO offer);
    public string SumUpProduct(Product product);
}