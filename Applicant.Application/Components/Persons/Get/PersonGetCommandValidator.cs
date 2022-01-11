using Applicant.Application.Components.Persons.Get;
using Applicant.Constants;
using FluentValidation;

namespace Applicant.Application.Components.Persons.Get
{
    public class PersonGetCommandValidator : AbstractValidator<PersonGetCommand>
    {
        public PersonGetCommandValidator(IPersonService personService)
        {
            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
                .NotEmpty().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
                .MustAsync(personService.Exists).WithErrorCode(ValidationErrorCodes.AlreadyExists.ToString()).WithMessage("NotFound");
        }
    }
}
