using Challenge.Dtos.CompanyDtos;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAllCompanies")]

        public async Task<ActionResult<ServiceResponse<List<CompanyDto>>>> Get()
        {
            return Ok(await _companyService.GetAllCompanies());
        }
    }
}
