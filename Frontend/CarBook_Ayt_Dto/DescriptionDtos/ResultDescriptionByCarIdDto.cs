using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Dto.DescriptionDtos
{
    public class ResultDescriptionByCarIdDto
    {
        public int CarDescriptionID { get; set; }
        public int CarID { get; set; }       
        public string Details { get; set; }
    }
}
