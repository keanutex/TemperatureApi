using System;

namespace TemperatureApi.Dtos
{
    public class AvgHumidityDataDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfDays { get; set; }
        public double AvgHumidity { get; set; }
    }
}
