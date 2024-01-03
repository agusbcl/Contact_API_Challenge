using Challenge.Dtos.ContactDtos;

namespace Challenge.Services.Interfaces
{
    public interface IContactService
    {
        Task<ServiceResponse<List<GetContactDto>>> AddContact(AddContactDto newContact);
        Task<ServiceResponse<List<GetContactDto>>> GetAllContacts();
        Task<ServiceResponse<GetContactDto>> GetContactById(int id);
        Task<ServiceResponse<GetContactDto>> UpdateContact(int id, UpdateContactDto updatedContact);
        Task<ServiceResponse<List<GetContactDto>>> DeleteContact(int id);
        Task<ServiceResponse<List<GetContactDto>>> GetContactByLocation(string location);
        Task<ServiceResponse<GetContactDto>> GetContactByEmailOrPhone(string emailOrPhone);

    }
}
