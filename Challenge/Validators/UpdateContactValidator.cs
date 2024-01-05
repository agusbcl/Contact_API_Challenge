using Challenge.Dtos.ContactDtos;
using Challenge.Services;
using Challenge.Services.Interfaces;
using FluentValidation;

namespace Challenge.Validators
{
    public class UpdateContactValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactValidator(ICityService cityService, ICompanyService companyService, IContactService contactService)
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(20);
            RuleFor(c => c.LastName).NotEmpty().MaximumLength(30);
            RuleFor(c => c.BirthDate).NotEmpty();
            RuleFor(c => c.Address).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Email).NotEmpty().EmailAddress().MaximumLength(100)
               .Must((obj, _) => NewEmailIsValid(obj, contactService))
               .WithMessage("{PropertyName}{PropertyValue} already exists.");
            RuleFor(c => c.Phone).NotEmpty().MaximumLength(12)
                .Must((obj, _) => NewPhoneIsValid(obj, contactService))
                .WithMessage("{PropertyName}{PropertyValue} already exists.");
            RuleFor(c => c.WorkPhone).NotEmpty()
            .MaximumLength(12)
                .Must((obj, _) => NewWorkPhoneIsValid(obj, contactService))
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
        private static bool NewEmailIsValid(UpdateContactDto contact, IContactService contactService)
        {
            var ServiceResponse = contactService.NewEmailIsValid(contact.Email, contact.Id);
            return !ServiceResponse.Data;
        }
        private static bool NewPhoneIsValid(UpdateContactDto contact, IContactService contactService)
        {
            var ServiceResponse = contactService.NewPhoneIsValid(contact.Phone, contact.Id);
            return !ServiceResponse.Data;
        }
        private static bool NewWorkPhoneIsValid(UpdateContactDto contact, IContactService contactService)
        {
            var ServiceResponse = contactService.NewWorkPhoneIsValid(contact.WorkPhone, contact.Id);
            return !ServiceResponse.Data;
        }
    }
}