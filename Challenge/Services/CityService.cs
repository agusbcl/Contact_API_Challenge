using AutoMapper.QueryableExtensions;
using Challenge.Dtos.CityDtos;
using Challenge.Services.Interfaces;

namespace Challenge.Services
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _dataContext;

        public CityService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<CityDto>>> GetAllCities()
        {
            var serviceResponse = new ServiceResponse<List<CityDto>>();

            try
            {
                serviceResponse.Data = await _dataContext.Cities.ProjectTo<CityDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<bool> CityExists(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                serviceResponse.Data = _dataContext.Cities.Any(x => x.Id == id);
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
