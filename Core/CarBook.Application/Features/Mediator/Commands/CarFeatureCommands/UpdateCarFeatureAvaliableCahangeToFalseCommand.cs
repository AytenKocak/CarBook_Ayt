using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvaliableCahangeToFalseCommand:IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvaliableCahangeToFalseCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
