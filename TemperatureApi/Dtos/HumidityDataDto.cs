using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace TemperatureApi.Dtos
{
     public class HumidityDataDto 
    {
        public DateTime date { get; set; }
        public double humidity_percentage { get; set; }
    }

}
