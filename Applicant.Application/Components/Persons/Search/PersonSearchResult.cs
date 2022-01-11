using Applicant.Application.Common.Mappings;
using Applicant.Core.Entities;
using AutoMapper;
using System;

namespace Applicant.Application.Components.Persons.Search
{
    public class PersonSearchResult : IMapFrom<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EMailAdress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; } = false;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonSearchResult>();
        }
    }
}
