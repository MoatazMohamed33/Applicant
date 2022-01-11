using Applicant.Application.Common.DataHelpers;
using Applicant.Application.Common.Responses;
using Applicant.Application.Components.Persons.Create;
using Applicant.Application.Components.Persons.Delete;
using Applicant.Application.Components.Persons.Edit;
using Applicant.Application.Components.Persons.Get;
using Applicant.Application.Components.Persons.Search;
using AspNetCore.ServiceRegistration.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Application
{
    public interface IPersonService : IScopedService
    {
        Task<OutputResponse<Pagination<PersonSearchResult>>> Search(PersonSearchQuery query);
        Task<OutputResponse<int>> Edit(PersonEditCommand command);
        Task<OutputResponse<bool>> Delete(PersonDeleteCommand request);
        Task<OutputResponse<PersonCreateCommandResult>> Create(PersonCreateCommand request);
        Task<OutputResponse<PersonGetCommandResult>> Get(PersonGetCommand request);
        Task<bool> Exists(int id, CancellationToken token);
    }
}
