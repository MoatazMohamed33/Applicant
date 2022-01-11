using System;
using Applicant.Application.Common.Responses;
using MediatR;

namespace Applicant.Application.Components.Persons.Get
{
    public class PersonGetCommand : IRequest<OutputResponse<PersonGetCommandResult>>
    {
        public int Id { get; set; }
    }
}
