using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applicant.Constants;
using FluentValidation;

namespace Applicant.Application.Components.Persons.Delete
{
    public class PersonDeleteCommandValidator : AbstractValidator<PersonDeleteCommand>
    {
        public PersonDeleteCommandValidator(IPersonService personService)
        {
            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
                .NotEmpty().WithErrorCode(ValidationErrorCodes.Required.ToString()).WithMessage("Mandatory")
                .MustAsync(personService.Exists).WithErrorCode(ValidationErrorCodes.NotExisting.ToString()).WithMessage("NotFound");
        }
    }
}
