using System;
using Applicant.Application.Common.DataHelpers;
using Applicant.Application.Common.Responses;
using MediatR;

namespace Applicant.Application.Components.Persons.Search
{
    public class PersonSearchQuery : BaseSearchModel, IRequest<OutputResponse<Pagination<PersonSearchResult>>>
    {

    }
}
