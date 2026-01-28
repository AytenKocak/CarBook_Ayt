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
    public  class CreateServiceQueryHandler:IRequestHandler<CreateServiceCommands,Unit>
    {
        private readonly IRepository<Service> _repository;

        public CreateServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateServiceCommands request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "İstek boş olamaz.");
            }
            await _repository.CreateAsync(new Service
            {
                Title = request.Title,
                Description = request.Description,
                IconUrl = request.IconUrl
            });
            return Unit.Value;

        }
    }
}
