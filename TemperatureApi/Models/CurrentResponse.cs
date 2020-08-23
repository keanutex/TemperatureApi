using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureApi.Models
{
    public class CurrentResponse
    {
        public LocationData location { get; set; }
        public CurrentData current { get; set; }
        public ErrorInfo error {get;set;}
    }

    public class ErrorInfo
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class LocationData
    {
        public String name { get; set; }
        public String region { get; set; }
        public String country { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public String tz_id { get; set; }
        public long localtime_epoch { get; set; }
        public DateTime localtime { get; set; }
    }

    public class CurrentData
    {
        public long last_updated_epoch { get; set; }
        public DateTime last_updated { get; set; }
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public int is_day { get; set; }
        public ConditionData condition { get; set; }
        public double wind_mph { get; set; }
        public double wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mb { get; set; }
        public double pressure_in { get; set; }
        public double precip_mm { get; set; }
        public double precip_in { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public double feelslike_c { get; set; }
        public double feelslike_f { get; set; }
        public double vis_km { get; set; }
        public double vis_miles { get; set; }
        public double uv { get; set; }
        public double gust_mph { get; set; }
        public double gust_kph { get; set; }
    }

    public class ConditionData
    {
        public string text { get; set; }
        public string icon { get; set; }
        public int code { get; set; }
    }
    
}
