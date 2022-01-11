using System.Threading;
using System.Threading.Tasks;
using Applicant.Application.Common.Responses;
using MediatR;

namespace Applicant.Application.Components.Persons.Delete
{
    public class PersonDeleteCommandHandler : IRequestHandler<PersonDeleteCommand, OutputResponse<bool>>
    {
        private readonly IPersonService _personService;
        public PersonDeleteCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public Task<OutputResponse<bool>> Handle(PersonDeleteCommand request, CancellationToken cancellationToken)
        {
            return _personService.Delete(request);
        }
    }
}
