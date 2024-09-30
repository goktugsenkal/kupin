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
    public ActionResult<Business> CreateBusiness(CreateBusinessDto business)
    {
        throw new NotImplementedException();
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