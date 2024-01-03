using AutoMapper.QueryableExtensions;
using Challenge.Dtos.RegionDto;
using Challenge.Services.Interfaces;

namespace Challenge.Services
{
    public class RegionService : IRegionService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _dataContext;

        public RegionService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<RegionDto>>> GetAllRegions()
        {
            var serviceResponse = new ServiceResponse<List<RegionDto>>();

            try
            {
                serviceResponse.Data = await _dataContext.Regions.ProjectTo<RegionDto>(_mapper.ConfigurationProvider).ToListAsync();
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
