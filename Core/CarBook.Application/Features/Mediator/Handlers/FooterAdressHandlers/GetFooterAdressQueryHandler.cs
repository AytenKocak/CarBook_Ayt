using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAdressResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAdressQuery, List<FooterAdressQueryResult>>

    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAdressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<FooterAdressQueryResult>> Handle(GetFooterAdressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new FooterAdressQueryResult
            {
                FooterAddressID = x.FooterAddressID,
                Description = x.Description,
                Address = x.Address,
                Phone = x.Phone,
                Emial = x.Emial
            }).ToList();
        }
    }
}
