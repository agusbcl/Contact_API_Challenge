using Challenge.Dtos.RegionDto;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet("GetAllRegions")]

        public async Task<ActionResult<ServiceResponse<List<RegionDto>>>> Get()
        {
            return Ok(await _regionService.GetAllRegions());
        }
    }
}
