using MediatR;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries
{
    // Buraya dikkat! Sınıfın yanına ": IRequest<SonuçTipi>" eklemelisin.
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int id)
        {
            Id = id;
        }
    }
}