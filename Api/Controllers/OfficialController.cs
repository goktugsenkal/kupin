using Api.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/business/{businessId:int}/official")]
public class OfficialController(IOfficialRepository officialRepository) 
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Official>>> GetAllOfficials
        (int businessId)
    {
        var officials = await officialRepository
            .GetAllOfficialsAsync(businessId);

        return Ok(officials);
    }

    [HttpGet("{officialId:int}")]
    public async Task<ActionResult<Official>> GetOfficialById
        (int businessId, int officialId)
    {
        var official = await officialRepository
            .GetOfficialByIdAsync(businessId, officialId);

        if (official == null) return NotFound();

        return Ok(official);
    }

    [HttpPost]
    public ActionResult<Official> CreateOfficial
        (int businessId, CreateOfficialDto officialForCreate)
    {
        throw new NotImplementedException();
    }
}