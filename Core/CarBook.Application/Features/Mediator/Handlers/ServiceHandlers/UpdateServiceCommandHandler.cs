using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Unit>
    {    private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(Commands.ServiceCommands.UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetByIdAsync(request.ServiceID);
            if (values != null)
            {
       
                values.Title = request.Title;
                values.Description = request.Description;
                values.IconUrl = request.IconUrl;
                await _repository.UpdateAsync(values);

            }
            return Unit.Value;


        }
    }
}
