using Challenge.Dtos.ContactDtos;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("GetAllContacts")]

        public async Task<ActionResult<ServiceResponse<List<GetContactDto>>>> GetAllContacts()
        {
            return Ok(await _contactService.GetAllContacts());
        }

        [HttpPost("AddNewContact")]
        public async Task<ActionResult<ServiceResponse<List<GetContactDto>>>> AddContact(AddContactDto newContact)
        {
            return Ok(await _contactService.AddContact(newContact));
        }

        [HttpGet("GetContactById{id}")]

        public async Task<ActionResult<ServiceResponse<GetContactDto>>> GetContactById(int id)
        {
            return Ok(await _contactService.GetContactById(id));
        }

        [HttpGet("GetContactByLocation/{location}")]

        public async Task<ActionResult<ServiceResponse<List<GetContactDto>>>> GetContactByLocation(string location)
        {
            return Ok(await _contactService.GetContactByLocation(location));
        }

        [HttpGet("GetContactByEmailOrPhone/{emailOrPhone}")]

        public async Task<ActionResult<ServiceResponse<GetContactDto>>> GetContactByEmailOrPhone(string emailOrPhone)
        {
            return Ok(await _contactService.GetContactByEmailOrPhone(emailOrPhone));
        }

        [HttpDelete("DeleteContact/{id}")]

        public async Task<ActionResult<ServiceResponse<GetContactDto>>> DeleteContact(int id)
        {
            var response = await _contactService.DeleteContact(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("UpdateContact/{id}")]

        public async Task<ActionResult<ServiceResponse<GetContactDto>>> UpdateContact(int id, UpdateContactDto updatedContact)
        {
            if(id != updatedContact.Id)
            {
                return BadRequest();
            }
            var response = await _contactService.UpdateContact(id, updatedContact);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
