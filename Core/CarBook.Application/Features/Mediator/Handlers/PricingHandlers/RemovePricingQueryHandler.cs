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
    public class RemovePricingQueryHandler : IRequestHandler<RemovePricingCommand, Unit>
    { private readonly IRepository<Pricing> _repository;

        public RemovePricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            if(values != null)
            throw new Exception("Pricing not found");
            await _repository.RemoveAsync(values);
            return Unit.Value;
        }
    }
}
