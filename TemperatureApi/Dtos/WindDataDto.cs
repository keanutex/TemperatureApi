using System;

namespace TemperatureApi.Dtos
{
     public class WindDataDto 
    {
        public DateTime date { get; set; }
        public double maxwind_mph { get; set; }
        public double maxwind_kph { get; set; }

        // WILL ADD IF THERE IS TIME:
        //public double wind_mph { get; set; }
        //public double wind_kph { get; set; }
        //public int wind_degree { get; set; }
        //public string wind_dir { get; set; }
        //public double gust_mph { get; set; }
        //public double gust_kph { get; set; }
    }

}
