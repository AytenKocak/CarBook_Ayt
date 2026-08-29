using MediatR;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries
{
 
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int id)
        {
            Id = id;
        }
    }
}