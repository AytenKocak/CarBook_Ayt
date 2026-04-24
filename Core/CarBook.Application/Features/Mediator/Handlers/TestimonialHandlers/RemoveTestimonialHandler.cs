using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialHandler : IRequestHandler<RemovetesTimonialCommand, Unit>
    { private readonly IRepository<Testimonial> _repository;

        public RemoveTestimonialHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async  Task<Unit> Handle(RemovetesTimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            if (values == null)
                throw new Exception("Testimonial bulunamadı");
            await _repository.RemoveAsync(values);
            return Unit.Value;


        }
    }
}
