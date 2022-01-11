using Applicant.Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Applicant.Application.Components.Persons.Get
{
    public class PersonGetCommandResult : IMapFrom<Applicant.Core.Entities.Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EMailAdress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap< Applicant.Core.Entities.Person, PersonGetCommandResult >().ReverseMap();
        }
    }
}
