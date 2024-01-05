using AutoMapper.QueryableExtensions;
using Challenge.Dtos.ContactDtos;
using Challenge.Services.Interfaces;

namespace Challenge.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _dataContext;

        public ContactService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetContactDto>>> AddContact(AddContactDto newContact)
        {
            var serviceResponse = new ServiceResponse<List<GetContactDto>>();

            try
            {
                var dbContact = _mapper.Map<Contact>(newContact);
                _dataContext.Contacts.Add(dbContact);

                await _dataContext.SaveChangesAsync();

                var dbContacts = await _dataContext.Contacts.ToListAsync();
                serviceResponse.Data = dbContacts.Select(c => _mapper.Map<GetContactDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetContactDto>>> GetAllContacts()
        {
            var serviceResponse = new ServiceResponse<List<GetContactDto>>();

            try
            {
                serviceResponse.Data = await _dataContext.Contacts
                    .ProjectTo<GetContactDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDto>> GetContactById(int id)
        {
            var serviceResponse = new ServiceResponse<GetContactDto>();

            try
            {
                serviceResponse.Data = await _dataContext.Contacts
                    .ProjectTo<GetContactDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetContactDto>>> GetContactByLocation(string location)
        {
            var serviceResponse = new ServiceResponse<List<GetContactDto>>();

            try
            {
                serviceResponse.Data = await _dataContext.Contacts
                    .Where(c => c.City.Name.ToLower() == location.ToLower() || c.City.Region.Name.ToLower() == location.ToLower())
                    .ProjectTo<GetContactDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDto>> GetContactByEmailOrPhone(string emailOrPhone)
        {
            var serviceResponse = new ServiceResponse<GetContactDto>();

            try
            {
                serviceResponse.Data = await _dataContext.Contacts
                    .Where(c => c.Email.ToLower() == emailOrPhone.ToLower() ||
                            c.Phone.ToLower() == emailOrPhone.ToLower() ||
                            c.WorkPhone.ToLower() == emailOrPhone.ToLower())
                    .ProjectTo<GetContactDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetContactDto>>> DeleteContact(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetContactDto>>();

            try
            {
                var dbContact = await _dataContext.Contacts.FirstOrDefaultAsync(c => c.Id == id);
                if (dbContact == null)
                {
                    throw new Exception($"Contact Id '{id}' not found.");
                }

                _dataContext.Contacts.Remove(dbContact);

                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = await _dataContext.Contacts.ProjectTo<GetContactDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDto>> UpdateContact(int id, UpdateContactDto updatedContact)
        {
            var serviceResponse = new ServiceResponse<GetContactDto>();

            try
            {
                var dbContact = await _dataContext.Contacts
                     .Include(c => c.City)
                     .Include(c => c.Company)
                     .AsTracking()
                     .FirstOrDefaultAsync(c => c.Id == id);
                if (dbContact == null)
                {
                    throw new Exception($"Contact Id '{id}' not found.");
                }

                _mapper.Map(updatedContact, dbContact);
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = await _dataContext.Contacts.ProjectTo<GetContactDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<bool> NewEmailIsValid(string email, int id = 0)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                serviceResponse.Data = _dataContext.Contacts.Any(c => c.Email == email && (id == 0 || c.Id != id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }            
            return serviceResponse;
        }

        public ServiceResponse<bool> NewPhoneIsValid(string phone, int id = 0)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                serviceResponse.Data = _dataContext.Contacts.Any(c => c.Phone == phone && (id == 0 || c.Id != id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<bool> NewWorkPhoneIsValid(string workPhone, int id = 0)
        {
            var serviceResponse = new ServiceResponse<bool>();
            
            try
            {
                serviceResponse.Data = _dataContext.Contacts.Any(c => c.WorkPhone == workPhone && (id == 0 || c.Id != id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}