using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyShop_kata.DTOs;
using MyShop_kata.Services.Interfaces;

namespace MyShop_kata.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class OfferController : Controller
{
    private readonly IOffersService _offersService;
    public OfferController(IOffersService offersService)
    {
        _offersService = offersService;
    }

    [HttpGet]
    [ProducesResponseType<OfferDTO>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<OfferDTO>>> Get()
    {
        try
        {
            var offers = await _offersService.GetAllOffers();
            return Ok(offers);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Post([FromBody] OfferDTO offer)
    {
        try
        {
            await _offersService.AddOffer(offer);
            return CreatedAtAction(nameof(Get), new { id = offer.ProductId }, offer);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Put([FromBody] OfferDTO offer)
    {
        try
        {
            await _offersService.UpdateOffer(offer);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}