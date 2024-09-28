using Api.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/business")]
public class BusinessesController : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<IReadOnlyList<Business>>> GetBusinesses()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:int}")]
    public Task<ActionResult<Business>> GetBusinessById()
    {
        throw new NotImplementedException();
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