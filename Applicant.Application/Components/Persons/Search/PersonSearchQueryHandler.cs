using Applicant.Application.Common.DataHelpers;
using Applicant.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Application.Components.Persons.Search
{
    public class PersonSearchQueryHandler : IRequestHandler<PersonSearchQuery, OutputResponse<Pagination<PersonSearchResult>>>
    {
        private readonly IPersonService _personService;
        public PersonSearchQueryHandler(IPersonService personService)
        {
            _personService = personService;
        }
        public async Task<OutputResponse<Pagination<PersonSearchResult>>> Handle(PersonSearchQuery request, CancellationToken cancellationToken)
        {
            return await _personService.Search(request);
        }
    }
}
