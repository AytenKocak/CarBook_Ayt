using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers.ReviewHandlers
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommands>
    { private readonly IRepository<Review> _repository;

        public UpdateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateReviewCommands request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetByIdAsync(request.ReviewId);
           values.CustomerName = request.CustomerName;
            values.CustomerImage = request.CustomerImage;
            values.Comment = request.Comment;
            values.RaytingValue = request.RaytingValue;
            values.ReviewDate = DateTime.Parse(request.ReviewDate.ToString("dd/MM/yyyy"));
            values.CarID = request.CarID;
            await _repository.UpdateAsync(values);
            return Unit.Value;

        }
    }
}
