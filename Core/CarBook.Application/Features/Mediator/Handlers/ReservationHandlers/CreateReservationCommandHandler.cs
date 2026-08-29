using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand,Unit>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Name = request.Name,
                SurName = request.SurName,
                EMail = request.EMail,
                Phone = request.Phone,
                PickUpLocationID = request.PickUpLocationID,
                DropOffLocationID = request.DropOffLocationID,
                CarID = request.CarID,
                Age = request.Age,
                DriverLicenseYear = request.DriverLicenseYear,
                Description = request.Description,
                Status = "Reservasyon Alındı"
            });

            return Unit.Value;
        }
    }
}

