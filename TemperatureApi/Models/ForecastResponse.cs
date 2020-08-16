using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureApi.Models
{
    public class ForecastResponse : CurrentResponse
    {
        public ForecastData forecast { get; set; }
    }

    public class ForecastData
    {
        public ForecastDataDay[] forecastday { get; set; }
    }

    public class ForecastDataDay
    {
        public DateTime date { get; set; }
        public long date_epoch { get; set; }
        public DayData day { get; set; }
        public AstroData astro { get; set; }
    }

    public class AstroData
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
    }

    public class DayData
    {
        public double maxtemp_c { get; set; }
        public double maxtemp_f { get; set; }
        public double mintemp_c { get; set; }
        public double mintemp_f { get; set; }
        public double avgtemp_c { get; set; }
        public double avgtemp_f { get; set; }
        public double maxwind_mph { get; set; }
        public double maxwind_kph { get; set; }
        public double totalprecip_mm { get; set; }
        public double totalprecip_in { get; set; }
        public double avgvis_km { get; set; }
        public double avgvis_miles { get; set; }
        public double avghumidity { get; set; }
        public int daily_will_it_rain { get; set; }
        public string daily_chance_of_rain { get; set; }
        public int daily_will_it_snow { get; set; }
        public string daily_chance_of_snow { get; set; }
        public ConditionData condition { get; set; }
        public double uv { get; set; }
    }
}
