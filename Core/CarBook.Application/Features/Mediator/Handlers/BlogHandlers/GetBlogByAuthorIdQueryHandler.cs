using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {  private readonly IBlogRepository _repository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
           var values=await _repository.GetBlogByAuthorId(request.Id);
            return values.Select(b => new GetBlogByAuthorIdQueryResult
            {
                BlogID = b.BlogID,               
                AuthorID = b.AuthorID,
                AuthorName = b.Author.Name,
                AuthorDescription = b.Author.Description,
                AuthorImageUrl = b.Author.ImageUrl
                
            }).ToList();
        }
    }
}
