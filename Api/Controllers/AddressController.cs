using Api.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/business/{businessId:int}/address")]
public class AddressController(IAddressRepository addressRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Address>>> GetAddresses(int businessId)
    {
        var addresses = await addressRepository
            .GetAllAddressesAsync(businessId);
        
        return Ok(addresses);
    }

    [HttpGet("{addressId:int}")]
    public async Task<ActionResult<Address?>> GetAddressById(int businessId, int addressId)
    {
	var address = await addressRepository.GetAddressByIdAsync(businessId, addressId);

	if(address == null) return NotFound();
	return Ok(address);
    }

    [HttpPost]
    public ActionResult<Address> CreateAddress
        (CreateAddressDto addressForCreate, int businessId)
    {
        var address = new Address
        {
            BusinessId = businessId,   
            Name = addressForCreate.Name,
            Street = addressForCreate.Street,
            County = addressForCreate.County,
            City = addressForCreate.City,
            AddressDescription = addressForCreate.AddressDescription,
        };
        
        addressRepository.CreateAddress(address);
        return Ok(address);
    }

    [HttpPut("{addressId:int}")]
    public async Task<ActionResult<Address>> UpdateAddress
        ( int businessId, int addressId, UpdateAddressDto addressForUpdate)
    {
        if (addressId != addressForUpdate.Id) return BadRequest();
        
        var address = await addressRepository
            .GetAddressByIdAsync(businessId, addressId);
        
        if(address == null) return NotFound();
        
        address.Name = addressForUpdate.Name;
        address.Street = addressForUpdate.Street;
        address.County = addressForUpdate.County;
        address.City = addressForUpdate.City;
        address.AddressDescription = addressForUpdate.AddressDescription;
        
        addressRepository.UpdateAddress(address);
        return Ok(address);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAddress(int businessId, int addressId)
    {
        var address = await addressRepository
            .GetAddressByIdAsync(businessId, addressId);
        
        if(address == null) return NotFound();
        
        addressRepository.DeleteAddress(address);
        
        return Ok(address);
    }
}
