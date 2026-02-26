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
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand, Unit>

    {
        private readonly IRepository<Author> _repository;

        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
           var values=await _repository.GetByIdAsync(request.Id);
            if (values == null)
            {
                throw new Exception("Author bulunamadı");
            }
            await _repository.RemoveAsync(values);
            return Unit.Value;
        }
    }
}
