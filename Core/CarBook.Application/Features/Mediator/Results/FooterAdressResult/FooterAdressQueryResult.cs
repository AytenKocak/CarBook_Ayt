using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.FooterAdressResult
{
    public class FooterAdressQueryResult
    {
        public int FooterAddressID { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Emial { get; set; }
    }
}
