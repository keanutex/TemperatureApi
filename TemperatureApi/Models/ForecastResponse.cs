using System;

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
        public HourData hour { get; set; }
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

    public class AstroData
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
        public string moon_phase { get; set; }
        public string moon_illumination { get; set; }
    }

    public class HourData
    {
        public int time_epoch { get; set; }
        public string time { get; set; }
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public double wind_mph { get; set; }
        public double wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mb { get; set; }
        public double pressure_in { get; set; }
        public int humidity { get; set; }
        public int cloud { get; set; }
        public double feelslike_c { get; set; }
        public double feelslike_f { get; set; }
        public double windchill_c { get; set; }
        public double windchill_f { get; set; }
        public double heatindex_c { get; set; }
        public double heatindex_f { get; set; }
        public double dewpoint_c { get; set; }
        public double dewpoint_f { get; set; }
        public int will_it_rain { get; set; }
        public int will_it_snow { get; set; }
        public int is_day { get; set; }
        public double vis_km { get; set; }
        public double vis_miles { get; set; }
        public int chance_of_rain { get; set; }
        public int chance_of_snow { get; set; }
        public double gust_mph { get; set; }
        public double gust_kph { get; set; }
    }
}
