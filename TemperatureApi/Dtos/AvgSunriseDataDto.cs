using System;

namespace TemperatureApi.Dtos
{
    public class AvgSunriseDataDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfDays { get; set; }
        public string AvgSunrise { get; set; }
    }
}
