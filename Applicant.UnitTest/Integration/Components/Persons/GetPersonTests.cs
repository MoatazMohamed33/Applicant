using System.Net;
using System.Threading.Tasks;
using Applicant.Application.Common.Responses;
using Applicant.Application.Components.Persons.Get;
using Applicant.Core.Entities;
using Applicant.Infrastructure;
using Applicant.UnitTest.Integration.Factories;
using Applicant.WebAPI;
using Consulting.UnitTest.Integration.Factories;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Applicant.UnitTest.Integration.Components.Persons
{
    public class GetPersonTests : IClassFixture<WebFixture<Startup>>
    {
        private readonly Requester _requester;
        private static int _validId;
        private static int _deletedId;

        public GetPersonTests(WebFixture<Startup> factory)
        {
            using var scope = factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            InitializeTestEnvironment(context);

            var client = factory.CreateClient();
            _requester = new Requester(client);
        }

        [Fact(DisplayName = "Invalid Get")]
        public async Task InvalidGetTest()
        {
            var result = await _requester.GetAsync<OutputResponse<PersonGetCommandResult>>($"/api/Person/person/{_deletedId}");

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest, because: "it shouldn't find deleted person");
            result.Success.Should().BeFalse(because: "it shouldn't find deleted person");
            result.Model.Should().BeNull("it shouldn't find deleted person");

            result = await _requester.GetAsync<OutputResponse<PersonGetCommandResult>>($"/api/Person/person/{int.MaxValue}");

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest, because: "it shouldn't find invalid person");
            result.Success.Should().BeFalse(because: "it shouldn't find invalid person");
            result.Model.Should().BeNull("it shouldn't find invalid person");
        }

        [Fact(DisplayName = "Successful Get")]
        public async Task SuccessfulGetTest()
        {
            var result = await _requester.GetAsync<OutputResponse<PersonGetCommandResult>>($"/api/Person/person/{_validId}");

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK, because: "it should have found the person");
            result.Success.Should().BeTrue(because: "it should have found the person");
            result.Model.Should().NotBeNull("it should retrieve the person");
            result.Model.Id.Should().Be(_validId, "it should retrieve the person");
            result.Errors.Should().BeNullOrEmpty(because: "it should not have any errors");
        }

        private void InitializeTestEnvironment(AppDbContext context)
        {
            var person = new Person { Id = 1000, Name = "Active Person", Age = 20, Address = "asss", CountryOfOrigin = "egypt", EMailAdress = "asss@fdgd.com", FamilyName = "ddd", Hired = true };
            var deletedPerson = new Person { Id = 1111, Name = "Deleted Person", IsDeleted = true, Age = 20, Address = "asss", CountryOfOrigin = "egypt", EMailAdress = "asss@fdgd.com", FamilyName = "ddd", Hired = true };
            context.Persons.Add(person);
            context.Persons.Add(deletedPerson);
            context.SaveChanges();
            _validId = person.Id;
            _deletedId = deletedPerson.Id;
        }
    }
}
