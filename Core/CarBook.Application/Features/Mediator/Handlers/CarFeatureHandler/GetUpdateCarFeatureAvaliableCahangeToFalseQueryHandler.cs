using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandler
{
    public class GetUpdateCarFeatureAvaliableCahangeToFalseQueryHandler : IRequestHandler<UpdateCarFeatureAvaliableCahangeToFalseCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public GetUpdateCarFeatureAvaliableCahangeToFalseQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public   Task<Unit> Handle(UpdateCarFeatureAvaliableCahangeToFalseCommand request, CancellationToken cancellationToken)
        {
           _repository.ChangeCarFeatureAvailableToFalse(request.Id);
            return Task.FromResult(Unit.Value);
        }
    }
}
