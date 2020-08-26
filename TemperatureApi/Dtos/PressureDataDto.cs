using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace TemperatureApi.Dtos
{
     public class PressureDataDto 
    {
        //public DateTime date { get; set; }
        public double pressure_mb { get; set; }
        public double pressure_in { get; set; }
    }

}
