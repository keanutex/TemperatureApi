using System;

namespace TemperatureApi.Dtos
{
    public class AvgPrecipitationDataDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfDays { get; set; }
        public double AvgTotalprecip_mm { get; set; }
        public double AvgTotalprecip_in { get; set; }

    }

}
