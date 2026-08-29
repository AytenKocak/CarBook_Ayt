using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescribtionResults;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescribtionHandlers
{
    public class GetCarDescriptionQueryHandler : IRequestHandler<GetCarDEscribtionByCarIdQuery, GetCarDEscribtionQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;

        public GetCarDescriptionQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDEscribtionQueryResult> Handle(GetCarDEscribtionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarDescriptionAsync(request.Id);

            // Null kontrolü eklendi
            if (values == null)
            {
                return null; // veya projenizin mimarisine göre throw new NotFoundException(...) atabilirsiniz.
            }

            return new GetCarDEscribtionQueryResult
            {
                CarDescriptionID = values.CarDescriptionID,
                CarID = values.CarID,
                Details = values.Details
            };
        }
    }
}
