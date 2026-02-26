using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResults>>
    {  private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public  async Task<List<GetAuthorQueryResults>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            
            var values= await _repository.GetAllAsync();
            return values .Select(x => new GetAuthorQueryResults
                {  AuthorID=x.AuthorID,
                   Name=x.Name,
                   ImageUrl=x.ImageUrl,
                   Description=x.Description

            }).ToList();     
            
        }
    }
}
