using Challenge.Dtos.CityDtos;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("GetAllCities")]

        public async Task<ActionResult<ServiceResponse<List<CityDto>>>> Get()
        {
            return Ok(await _cityService.GetAllCities());
        }
    }
}
