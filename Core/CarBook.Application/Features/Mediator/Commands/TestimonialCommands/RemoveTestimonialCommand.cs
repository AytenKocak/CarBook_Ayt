using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemovetesTimonialCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public RemovetesTimonialCommand(int id)
        {
            Id = id;
        }
    }
}