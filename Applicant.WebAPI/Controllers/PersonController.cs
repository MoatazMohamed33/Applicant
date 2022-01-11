using Applicant.Application.Common.DataHelpers;
using Applicant.Application.Common.Responses;
using Applicant.Application.Components.Persons.Create;
using Applicant.Application.Components.Persons.Delete;
using Applicant.Application.Components.Persons.Edit;
using Applicant.Application.Components.Persons.Get;
using Applicant.Application.Components.Persons.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Applicant.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : CoreController
    {
        [HttpPost("search")]
        [ProducesResponseType(typeof(OutputResponse<Pagination<PersonSearchResult>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Search(PersonSearchQuery query)
        {
            var result = await Mediator.Send(query);
            return ReturnResult(result);
        }

        [HttpDelete("person/{id}")]
        [ProducesResponseType(typeof(OutputResponse<bool>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new PersonDeleteCommand { Id = id };
            var result = await Mediator.Send(command);
            return ReturnResult(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(OutputResponse<PersonCreateCommandResult>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromForm] PersonCreateCommand command)
        {
            var result = await Mediator.Send(command);
            return ReturnResult(result);
        }

        [HttpGet("person/{id}")]
        [ProducesResponseType(typeof(OutputResponse<PersonGetCommandResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(OutputResponse<object>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var command = new PersonGetCommand { Id = id };
            var result = await Mediator.Send(command);
            return ReturnResult(result);
        }

        [HttpPut("edit")]
        [ProducesResponseType(typeof(OutputResponse<int>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(OutputResponse<>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Edit(PersonEditCommand command)
        {
            var result = await Mediator.Send(command);
            return ReturnResult(result);
        }
    }
}
