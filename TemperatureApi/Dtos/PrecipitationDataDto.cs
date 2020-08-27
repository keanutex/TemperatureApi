using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace TemperatureApi.Dtos
{
     public class PrecipitationDataDto 
    {
        public DateTime date { get; set; }
        public double totalprecip_mm { get; set; }
        public double totalprecip_in { get; set; }

    }

}
