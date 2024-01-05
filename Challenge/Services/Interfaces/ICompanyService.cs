using Challenge.Dtos.CompanyDtos;

namespace Challenge.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<ServiceResponse<List<CompanyDto>>> GetAllCompanies();
        ServiceResponse<bool> CompanyExists(int id);
    }
}
