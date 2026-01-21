using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQueries
    {
        public int Id { get; set; }

        public GetContactByIdQueries(int id)
        {
            Id = id;
        }
    }
}
