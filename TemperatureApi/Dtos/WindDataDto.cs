using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace TemperatureApi.Dtos
{
     public class WindDataDto 
    {
        public DateTime date { get; set; }
        public double maxwind_mph { get; set; }
        public double maxwind_kph { get; set; }
        //public int wind_degree { get; set; }
        //public string wind_dir { get; set; }
        //public double gust_mph { get; set; }
        //public double gust_kph { get; set; }
    }

}
