using System;

namespace TemperatureApi.Dtos
{
     public class HumidityDataDto 
    {
        public DateTime date { get; set; }
        public double humidity_percentage { get; set; }
    }

}
