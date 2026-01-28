using CarBook.Application.Features.Mediator.Commands.CreateFeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand, Unit>
    { private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async  Task<Unit> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetByIdAsync(request.FeatureID);
            if (values == null)
                throw new Exception("Feature bulunamadı");
            values.Name = request.Name;
              await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
