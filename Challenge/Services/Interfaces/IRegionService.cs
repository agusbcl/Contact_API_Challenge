using Challenge.Dtos.RegionDto;

namespace Challenge.Services.Interfaces
{
    public interface IRegionService
    {
        Task<ServiceResponse<List<RegionDto>>> GetAllRegions();
    }
}
