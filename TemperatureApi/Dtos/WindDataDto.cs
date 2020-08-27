using System;

namespace TemperatureApi.Dtos
{
     public class WindDataDto 
    {
        public DateTime date { get; set; }
        public double maxwind_mph { get; set; }
        public double maxwind_kph { get; set; }

    }

}
