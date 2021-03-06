﻿using System;

namespace TemperatureApi.Dtos
{
    public class AvgSunsetDataDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NumberOfDays { get; set; }
        public string AvgSunset { get; set; }
    }
}
