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
    public class CreateTagColudCommandHandler : IRequestHandler<CreateTagCloudCommand, Unit>
    {

        private readonly IRepository<TagCloud> _repository;

        public CreateTagColudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async  Task<Unit> Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "İstek boş olamaz.");
            }
            await _repository.CreateAsync(new TagCloud
            {
                Title=request.Title,
                BlogID=request.BlogID   
            });

            return Unit.Value;

        }
    }


}
