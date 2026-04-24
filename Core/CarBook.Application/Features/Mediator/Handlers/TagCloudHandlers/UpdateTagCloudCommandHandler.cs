using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand, Unit>
    { private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async  Task<Unit> Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
           var value=await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                throw new Exception("TagCloud not found");
            }
            value.Title = request.Title;
            value.BlogID = request.BlogID;
            await _repository.UpdateAsync(value);
            return Unit.Value;
        }
    }
}
