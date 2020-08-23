using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace TemperatureApi.Dtos
{
     public class PrecipDataDto 
    {
        public double precip_mm { get; set; }
        public double precip_in { get; set; }
    }

}
