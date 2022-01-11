using System.Threading;
using System.Threading.Tasks;
using Applicant.Application.Common.Responses;
using MediatR;

namespace Applicant.Application.Components.Persons.Create
{
    public class PersonCreateCommandHandler : IRequestHandler<PersonCreateCommand, OutputResponse<PersonCreateCommandResult>>
    {
        private readonly IPersonService _personService;

        public PersonCreateCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<OutputResponse<PersonCreateCommandResult>> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
        {
            var result = await _personService.Create(request);
            return result;
        }
    }
}
