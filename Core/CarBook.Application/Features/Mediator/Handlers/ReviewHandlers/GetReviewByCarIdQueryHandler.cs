using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.ReviewRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResults>>

    {
        private readonly IReviewRepository _repository;

        public GetReviewByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResults>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetReviewsByCarIdAsync(request.Id);

            return values.Select(x => new GetReviewByCarIdQueryResults
            {
                CarID = x.CarID,
                ReviewDate = x.ReviewDate,
                ReviewID = x.ReviewID,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                Comment = x.Comment,
                RaytingValue = x.RaytingValue

            }).ToList();
        }
    }
}
