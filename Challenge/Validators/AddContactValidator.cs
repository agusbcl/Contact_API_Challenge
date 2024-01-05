using Challenge.Dtos.ContactDtos;
using Challenge.Services.Interfaces;
using FluentValidation;

namespace Challenge.Validators
{
    public class AddContactValidator : AbstractValidator<AddContactDto>
    {
        public AddContactValidator(ICityService cityService, ICompanyService companyService, IContactService contactService)
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(20);
            RuleFor(c => c.LastName).NotEmpty().MaximumLength(30);
            RuleFor(c => c.BirthDate).NotEmpty().LessThan(DateTime.Today);
            RuleFor(c => c.Address).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Email).NotEmpty().EmailAddress().MaximumLength(100)
                .Must(email => NewEmailIsValid(email, contactService))
                .WithMessage("{PropertyName}{PropertyValue} already exists.");
            RuleFor(c => c.Phone).NotEmpty().MaximumLength(12)
                .Must(phone => NewPhoneIsValid(phone, contactService))
                .WithMessage("{PropertyName}{PropertyValue} already exists.");
            RuleFor(c => c.WorkPhone).NotEmpty()
                .MaximumLength(12)
                .Must(workPhone => NewWorkPhoneIsValid(workPhone, contactService))
                .WithMessage("{PropertyName}{PropertyValue} already exists.");
            RuleFor(c => c.CityId).NotEmpty()
                .Must(cityId => CityExists(cityId, cityService))
                .WithMessage("{PropertyName} : {PropertyValue} not found.");
            RuleFor(c => c.CompanyId).NotEmpty()
                .Must(companyId => CompanyExists(companyId, companyService))
                .WithMessage("{PropertyName} : {PropertyValue} not found.");
        }
        private static bool CityExists(int cityId, ICityService cityService)
        {
            var serviceResponse = cityService.CityExists(cityId);
            return serviceResponse.Data;
        }
        private static bool CompanyExists(int companyId, ICompanyService companyService)
        {
            var ServiceResponse = companyService.CompanyExists(companyId);
            return ServiceResponse.Data;
        }
        private static bool NewEmailIsValid(string email, IContactService contactService)
        {
            var ServiceResponse = contactService.NewEmailIsValid(email);
            return !ServiceResponse.Data;
        }
        private static bool NewPhoneIsValid(string phone, IContactService contactService)
        {
            var ServiceResponse = contactService.NewPhoneIsValid(phone);
            return !ServiceResponse.Data;
        }
        private static bool NewWorkPhoneIsValid(string workPhone, IContactService contactService)
        {
            var ServiceResponse = contactService.NewWorkPhoneIsValid(workPhone);
            return !ServiceResponse.Data;
        }
    }
}