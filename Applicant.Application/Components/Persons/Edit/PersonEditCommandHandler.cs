using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Applicant.Application;
using Applicant.Application.Common.Responses;
using MediatR;

namespace Applicant.Application.Components.Persons.Edit
{
    public class PersonEditCommandHandler : IRequestHandler<PersonEditCommand, OutputResponse<int>>
    {
        private readonly IPersonService _personService;

        public PersonEditCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<OutputResponse<int>> Handle(PersonEditCommand request, CancellationToken cancellationToken)
        {
            return await _personService.Edit(request);
        }
    }
}
