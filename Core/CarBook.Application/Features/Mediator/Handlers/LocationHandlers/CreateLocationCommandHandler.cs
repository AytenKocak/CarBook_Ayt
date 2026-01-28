using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationFolder
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand,Unit>
    {
        private readonly IRepository<Location> _repository;

        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "İstek boş olamaz.");
            }
            await _repository.CreateAsync(new Location
            {
                Name = request.Name
            });

            return Unit.Value;
        }
    }
}
