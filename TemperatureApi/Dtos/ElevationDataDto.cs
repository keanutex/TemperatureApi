using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace TemperatureApi.Dtos
{
     public class ElevationDataDto 
    {
        public double latitude { get; set; }
        public int elevation { get; set; }
        public double longitude { get; set; }
    }

}
