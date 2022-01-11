using Applicant.Application;
using Applicant.Application.Common.DataHelpers;
using Applicant.Application.Common.Responses;
using Applicant.Application.Components.Persons.Create;
using Applicant.Application.Components.Persons.Delete;
using Applicant.Application.Components.Persons.Edit;
using Applicant.Application.Components.Persons.Get;
using Applicant.Application.Components.Persons.Search;
using Applicant.Core.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Infrastructure.Components
{
    public class PersonManager : IPersonService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PersonManager(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OutputResponse<PersonCreateCommandResult>> Create(PersonCreateCommand request)
        {
            var person = _mapper.Map<Person>(request);
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            var res = _mapper.Map<PersonCreateCommandResult>(person);
            return new OutputResponse<PersonCreateCommandResult>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                Message = "Success",
                Model = res
            };
        }

        public async Task<OutputResponse<bool>> Delete(PersonDeleteCommand request)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(t => t.Id == request.Id && t.IsDeleted==false);
            person.IsDeleted = true;
            _context.Update(person);
            await _context.SaveChangesAsync();
            return new OutputResponse<bool>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                Message = "Success",
                Model = true
            };
        }

        public async Task<OutputResponse<int>> Edit(PersonEditCommand command)
        {
            var person = await _context.Persons.FindAsync(command.Id);
            person.Name = command.Name;
            person.FamilyName = command.FamilyName;
            person.Address = command.Address;
            person.EMailAdress = command.EMailAdress;
            person.Age = command.Age;
            person.CountryOfOrigin = command.CountryOfOrigin;
            person.Hired = command.Hired;
            await _context.SaveChangesAsync();

            return new OutputResponse<int>
            {
                Success = true,
                StatusCode = HttpStatusCode.Created,
                Message = "Success",
                Model = command.Id
            };
        }

        public async Task<bool> Exists(int id, CancellationToken token)
        {
            return await _context.Persons.AnyAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task<OutputResponse<PersonGetCommandResult>> Get(PersonGetCommand request)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(c => c.Id == request.Id && !c.IsDeleted);

            return new OutputResponse<PersonGetCommandResult>
            {
                Success = person != null,
                StatusCode = person == null ? HttpStatusCode.NotFound : HttpStatusCode.OK,
                Message = person == null ? "NotFound" : "Success",
                Model = _mapper.Map<PersonGetCommandResult>(person)
            };
        }

        public async Task<OutputResponse<Pagination<PersonSearchResult>>> Search(PersonSearchQuery query)
        {
            return await Task.Run(() =>
            {
                var queryStatement = _mapper.ProjectTo<PersonSearchResult>(_context.Persons.Where(a => !a.IsDeleted ));
                var list = new Pagination<PersonSearchResult>(queryStatement, query.PageNumber, query.PageSize);
                return new OutputResponse<Pagination<PersonSearchResult>>
                {
                    Success = list.TotalCount > 0,
                    StatusCode = list.TotalCount > 0 ? HttpStatusCode.OK : HttpStatusCode.NotFound,
                    Message = list.TotalCount > 0 ? "Success" : "EmptyResult",
                    Model = list
                };
            });
        }
    }
}
