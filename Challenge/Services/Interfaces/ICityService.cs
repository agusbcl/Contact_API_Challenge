using Challenge.Dtos.CityDtos;

namespace Challenge.Services.Interfaces
{
    public interface ICityService
    {
        Task<ServiceResponse<List<CityDto>>> GetAllCities();
    }
}
