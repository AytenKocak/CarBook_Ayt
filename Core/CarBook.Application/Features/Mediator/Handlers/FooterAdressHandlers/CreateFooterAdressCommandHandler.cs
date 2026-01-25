using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class CreateFooterAdressCommandHandler : IRequestHandler<CreateFooterAdressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public CreateFooterAdressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async  Task<Unit> Handle(CreateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAddress
            {

                Description = request.Description,
                Address = request.Address,
                Phone = request.Phone,
                Emial = request.Emial
            });
            return Unit.Value;
        }
    }
}
