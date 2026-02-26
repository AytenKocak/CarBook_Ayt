using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler :IRequestHandler<CreateAuthorCommand,Unit>
    {
        private readonly IRepository<Author> _repository;

        public CreateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async  Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request), "İstek boş olamaz.");
            }
            await _repository.CreateAsync(new Author
            {
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Description = request.Description
            });
            return Unit.Value;
        }
    }
}
