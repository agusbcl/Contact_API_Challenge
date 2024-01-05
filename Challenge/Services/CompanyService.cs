using AutoMapper.QueryableExtensions;
using Challenge.Dtos.CompanyDtos;
using Challenge.Services.Interfaces;

namespace Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _dataContext;

        public CompanyService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<CompanyDto>>> GetAllCompanies()
        {
            var serviceResponse = new ServiceResponse<List<CompanyDto>>();

            try
            {
                serviceResponse.Data = await _dataContext.Companies.ProjectTo<CompanyDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<bool> CompanyExists(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                serviceResponse.Data = _dataContext.Companies.Any(c => c.Id == id);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        } 
    }
}
