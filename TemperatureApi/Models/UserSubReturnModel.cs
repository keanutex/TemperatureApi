using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureApi.Models
{
    public class UserSubReturnModel
    {

        public string city { get; set; }
        public float temp { get; set; }
        public string condition { get; set; }
    }
}
