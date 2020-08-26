using System;

namespace TemperatureApi.Dtos
{
     public class AvgWindDataDto 
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfDays { get; set; }
        public double AvgMaxwind_mph { get; set; }
        public double AvgMaxwind_kph { get; set; }
    }
}