﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace TemperatureApi.Dtos
{
     public class SunsetDataDto 
    {
        public DateTime date { get; set; }
        public string sunset { get; set; }
    }

}