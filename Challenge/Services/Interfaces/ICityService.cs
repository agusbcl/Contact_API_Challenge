using Challenge.Dtos.CityDtos;
using System.Threading;

namespace Challenge.Services.Interfaces
{
    public interface ICityService
    {
        Task<ServiceResponse<List<CityDto>>> GetAllCities();
        ServiceResponse<bool> CityExists(int id);
    }
}
