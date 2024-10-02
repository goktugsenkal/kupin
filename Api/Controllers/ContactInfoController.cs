using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/business/{businessId:int}/contactInfo")]
public class ContactInfoController
    (IContactInfoRepository contactInfoRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ContactInfo>> GetContactInfo(int businessId)
    {
        var contactInfo = await contactInfoRepository
            .GetAllContactInfoAsync(businessId);
        
        return Ok(contactInfo);
    }

    [HttpGet("{contactInfoId:int}")]
    public async Task<ActionResult<ContactInfo>> GetContactInfo(int businessId, int contactInfoId)
    {
        var contactInfo = await contactInfoRepository
            .GetContactInfoByIdAsync(businessId, contactInfoId);
        
        return Ok(contactInfo);
    }

    [HttpPost]
    public ActionResult<ContactInfo> CreateContactInfo(ContactInfo contactInfo)
    {
        contactInfoRepository.CreateContactInfo(contactInfo);
        return Ok(contactInfo);
    }
}