using Api.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/business/{businessId:int}/contactInfo")]
public class ContactInfoController(IContactInfoRepository contactInfoRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ContactInfo>> GetContactInfo(int businessId)
    {
        var contactInfo = await contactInfoRepository.GetAllContactInfoAsync(businessId);

        return Ok(contactInfo);
    }

    [HttpGet("{contactInfoId:int}")]
    public async Task<ActionResult<ContactInfo>> GetContactInfo(int businessId, int contactInfoId)
    {
        var contactInfo = await contactInfoRepository.GetContactInfoByIdAsync(
            businessId,
            contactInfoId
        );

        if (contactInfo == null)
            return NotFound();

        return Ok(contactInfo);
    }

    [HttpPost]
    public ActionResult<ContactInfo> CreateContactInfo(
        CreateContactInfoDto contactInfoForCreate,
        int businessId
    )
    {
        var contactInfo = new ContactInfo
        {
            BusinessId = businessId,
            AuthorizedPersonnel = contactInfoForCreate.AuthorizedPersonnel.ToListOfOfficials(),
            MailAddresses = contactInfoForCreate.MailAddresses,
            PhoneNumbers = contactInfoForCreate.PhoneNumbers,
        };

        contactInfoRepository.CreateContactInfo(contactInfo);
        return Ok(contactInfo);
    }

    [HttpPut("{contactInfoId:int}")]
    public async Task<ActionResult<ContactInfo>> UpdateContactInfo(
        UpdateContactInfoDto contactInfoForUpdate,
        int businessId,
        int contactInfoId)
    {
        var contactInfo = await contactInfoRepository.GetContactInfoByIdAsync(businessId, contactInfoId);

        if (contactInfo == null) return NotFound();

        contactInfo.MailAddresses = contactInfoForUpdate.MailAddresses;
        contactInfo.PhoneNumbers = contactInfoForUpdate.PhoneNumbers;
        contactInfo.AuthorizedPersonnel = contactInfoForUpdate.AuthorizedPersonnel
            .ToListOfOfficials();

        contactInfoRepository.UpdateContactInfo(contactInfo);
        return Ok(contactInfo);
    }

    [HttpDelete("{contactInfoId:int}")]
    public async Task<ActionResult> DeleteContactInfo(int businessId, int contactInfoId)
    {
        var contactInfo = await contactInfoRepository.GetContactInfoByIdAsync(
            businessId,
            contactInfoId
        );

        if (contactInfo == null)
            return NotFound();

        contactInfoRepository.DeleteContactInfo(contactInfo);

        return Ok();
    }
}

