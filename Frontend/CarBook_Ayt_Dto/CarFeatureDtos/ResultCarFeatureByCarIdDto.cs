using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Dto.CarFeatureDtos
{
    public class ResultCarFeatureByCarIdDto
    {
        public int CarFeatureID { get; set; }
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }


    }
}
