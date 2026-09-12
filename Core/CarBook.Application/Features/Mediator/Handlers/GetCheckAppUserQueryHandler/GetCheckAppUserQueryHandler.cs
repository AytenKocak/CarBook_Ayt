using CarBook.Application.Features.Mediator.Queries.GetCheckAppUserQuery;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.AppRoleInterfaces;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.GetCheckAppUserQueryHandler
{
    public class GetCheckAppUserQueryHandler
      : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResults>
    {
        private readonly IRepository<AppRole> _appRoleRepository;
        private readonly IRepository<AppUser> _appUserrepository;

        public GetCheckAppUserQueryHandler(IRepository<AppRole> appRoleRepository, IRepository<AppUser> appUserrepository)
        {
            _appRoleRepository = appRoleRepository;
            _appUserrepository = appUserrepository;
        }

        public async Task<GetCheckAppUserQueryResults> Handle(
            GetCheckAppUserQuery request,
            CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResults();

            var user = await _appUserrepository.GetByFilterAsync(
                x => x.UserName == request.UserName &&
                     x.Password == request.Password);

            if (user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.UserName = user.UserName;
                values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId==user.AppleId)).AppRoleName;
                values.Id = user.AppUserId;
            }

            return values;
        }
    }
}