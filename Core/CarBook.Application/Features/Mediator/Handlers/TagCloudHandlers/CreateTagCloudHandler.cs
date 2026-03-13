using CarBook.Application.Features.Mediator.Commands.TagClodCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class CreateTagCloudHandler : IRequestHandler<CreateTagCloudCommand>
    {
        public readonly IRepository<TagCloud> _repository;

        public CreateTagCloudHandler(IRepository<TagCloud> repository)
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
               BlogID = request.BlogID,
                Title = request.Title,

            }); return Unit.Value;



        }
    }
}
