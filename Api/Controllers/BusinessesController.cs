using Api.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/business")]
public class BusinessesController(IBusinessRepository businessRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Business>>> GetBusinesses()
    {
        var businesses = await businessRepository.GetAllBusinessesAsync();
        
        return Ok(businesses);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Business>> GetBusinessById(int id)
    {
        var business = await businessRepository.GetBusinessByIdAsync(id);
        if (business == null) { return NotFound(); }
        
        return Ok(business);
    }

    [HttpPost]
    public ActionResult<Business> CreateBusiness(CreateBusinessDto businessForCreate)
    {
        var business = new Business
        {
        Name = businessForCreate.Name,
        Description = businessForCreate.Description,
        ImageUrl = businessForCreate.ImageUrl ?? "https://placehold.co/200x200?text=business",
        BusinessType = businessForCreate.BusinessType,
        IsActive = false
        };
        
        businessRepository.CreateBusiness(business);
        return CreatedAtAction(nameof(GetBusinessById), new { id = business.Id }, business);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Business> UpdateBusiness(UpdateBusinessDto business, int id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteBusiness(int id)
    {
        throw new NotImplementedException();
    }
}