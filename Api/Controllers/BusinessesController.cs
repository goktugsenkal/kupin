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
    public async Task<ActionResult<Business>> UpdateBusiness(UpdateBusinessDto businessForUpdate, int id)
    {
        if (id != businessForUpdate.Id) { return BadRequest(); }
        
        var business = await businessRepository.GetBusinessByIdAsync(id);
        
        if (business == null) { return BadRequest(); }
        
        business.Name = businessForUpdate.Name;
        business.Description = businessForUpdate.Description;
        business.ImageUrl = businessForUpdate.ImageUrl ?? "https://placehold.co/200x200?text=business";
        business.BusinessType = businessForUpdate.BusinessType;
        business.IsActive = business.IsActive;
        
        businessRepository.UpdateBusiness(business);
        return Ok(business);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBusiness(int id)
    {
        var business = await businessRepository.GetBusinessByIdAsync(id);
        
        if (business != null) businessRepository.DeleteBusiness(business);

        return Ok();
    }
}