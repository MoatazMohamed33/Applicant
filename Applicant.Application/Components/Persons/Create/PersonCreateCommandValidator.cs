using Applicant.Constants;
using FluentValidation;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Application.Components.Persons.Create
{
    public class PersonCreateCommandValidator : AbstractValidator<PersonCreateCommand>
    {


        public PersonCreateCommandValidator(ICountryService countryService)
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(c => c.Name)
                .NotNull().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
                .NotEmpty().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
                .MinimumLength(5).WithErrorCode(ValidationErrorCodes.NotCorrectLength.ToString()).WithMessage("MinimumLength is 5");

            RuleFor(c => c.FamilyName)
               .NotNull().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
               .NotEmpty().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
               .MinimumLength(5).WithErrorCode(ValidationErrorCodes.NotCorrectLength.ToString()).WithMessage("MinimumLength is 5");

            RuleFor(c => c.Address)
               .NotNull().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
               .NotEmpty().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
               .MinimumLength(10).WithErrorCode(ValidationErrorCodes.NotCorrectLength.ToString()).WithMessage("MinimumLength is 10");

            RuleFor(c => c.CountryOfOrigin)
              .NotNull().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
              .NotEmpty().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
              .MustAsync(countryService.CheckCountry).WithErrorCode(ValidationErrorCodes.NotExisting.ToString()).WithMessage("Country Not Found");

            RuleFor(c => c.EMailAdress)
              .NotNull().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
              .NotEmpty().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
              .EmailAddress().WithErrorCode(ValidationErrorCodes.NotValidEmailAddress.ToString()).WithMessage("Not Valid Email Address");

            RuleFor(c => c.Age)
             .NotEqual(0).WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
             .InclusiveBetween(20, 60).WithErrorCode(ValidationErrorCodes.NotIdentical.ToString()).WithMessage("Value must be number Beetween 20,60");

            RuleFor(c => c.Hired)
             .NotNull().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory");
        }
    }
}
