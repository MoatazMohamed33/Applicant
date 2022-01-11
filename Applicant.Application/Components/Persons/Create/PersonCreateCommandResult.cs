using Applicant.Application.Common.Mappings;
using Applicant.Core.Entities;
using AutoMapper;
using System;

namespace Applicant.Application.Components.Persons.Create
{
    public class PersonCreateCommandResult : IMapFrom<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonCreateCommandResult>();
        }
    }
}
