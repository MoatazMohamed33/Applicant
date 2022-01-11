using System;
using System.Collections.Generic;
using Applicant.Application.Common.Mappings;
using Applicant.Application.Common.Responses;
using Applicant.Core.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Applicant.Application.Components.Persons.Create
{
    public class PersonCreateCommand : IRequest<OutputResponse<PersonCreateCommandResult>>, IMapFrom<Person>
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EMailAdress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonCreateCommand, Person>();
        }
    }
}
