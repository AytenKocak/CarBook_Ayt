using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResult;
using CarBook.Application.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentCountByBlogQueryHandler : IRequestHandler<GetCommentCountByBlogQuery, GetCommentCountByBlogQueryResult>
    {
        private readonly IGenericRepository<Comment> _repository;

        public GetCommentCountByBlogQueryHandler(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }
        public Task<GetCommentCountByBlogQueryResult> Handle(
        GetCommentCountByBlogQuery request,
        CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetCommentCountByBlogQueryResult
            {
                Count = _repository.GetCountCommentByBlog(request.Id)
            });
        }
    }
}
