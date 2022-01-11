using System.Threading;
using System.Threading.Tasks;
using Applicant.Application.Common.Responses;
using Applicant.Application.Components.Persons.Get;
using MediatR;

namespace Applicant.Application.Components.Persons.Get
{
    public class PersonGetCommandHandler : IRequestHandler<PersonGetCommand, OutputResponse<PersonGetCommandResult>>
    {
        private readonly IPersonService _personService;

        public PersonGetCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public Task<OutputResponse<PersonGetCommandResult>> Handle(PersonGetCommand request, CancellationToken cancellationToken)
        {
            return _personService.Get(request);
        }
    }
}
