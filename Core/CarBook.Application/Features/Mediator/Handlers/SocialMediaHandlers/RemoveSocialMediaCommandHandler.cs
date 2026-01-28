using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand, Unit>
    {
        private readonly IRepository<SocialMedia> _reppository;

        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> reppository)
        {
            _reppository = reppository;
        }

        public async Task<Unit> Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value=await _reppository.GetByIdAsync(request.Id);
            if (value == null) 
            { throw new Exception("Silinecek Sosyal Medya Bulunamadı"); }
            await _reppository.RemoveAsync(value);
            return Unit.Value;
        }
    }
}
