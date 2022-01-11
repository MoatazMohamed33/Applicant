using System;
using Applicant.Application.Common.Responses;
using MediatR;

namespace Applicant.Application.Components.Persons.Delete
{
    public class PersonDeleteCommand : IRequest<OutputResponse<bool>>
    {
        public int Id { get; set; }
    }
}
