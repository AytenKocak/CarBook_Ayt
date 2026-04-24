using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandler
{
    public class UpdatePricingQueryHandler : IRequestHandler<UpdatePricingCommand, Unit>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        { var values= await _repository.GetByIdAsync(request.PricingID);
            if (values != null)
            {
                values.Name = request.Name;
                await _repository.UpdateAsync(values);
            }
            return Unit.Value;  

        }
    }
}
