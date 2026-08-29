using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvaliableCahangeToTrueCommand:IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvaliableCahangeToTrueCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
