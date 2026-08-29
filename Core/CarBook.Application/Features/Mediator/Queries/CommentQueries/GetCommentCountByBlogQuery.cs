using CarBook.Application.Features.Mediator.Results.CommentResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentCountByBlogQuery:IRequest<GetCommentCountByBlogQueryResult>
    {
        public int Id { get; set; }

        public GetCommentCountByBlogQuery(int id)
        {
            Id = id;
        }
    }
}
