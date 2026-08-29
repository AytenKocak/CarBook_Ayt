using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandler
{
    public class CreateCarFeatureByCarCommandQueryHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private
             readonly ICarFeatureRepository _repository;

        public CreateCarFeatureByCarCommandQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            _repository.CreateCarFeatureByCar(new CarFeature
            {
                CarFeatureID = request.CarFeatureID,
                CarID = request.CarID,
                FeatureID = request.FeatureID,
                Available = request.Available





            });


            return Unit.Value;


        }
    }
}
