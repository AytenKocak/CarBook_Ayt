using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationFolder
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand,Unit>
    {   private readonly IRepository<Location> _repository;
        public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {

            var values=await _repository.GetByIdAsync(request.LocationID);
            if (values == null)
                throw new Exception("Location bulunamadı");
            values.Name = request.Name; 
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
