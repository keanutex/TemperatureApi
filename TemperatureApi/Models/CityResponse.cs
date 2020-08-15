using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureApi.Models
{
    public class CityResponse
    {
        public Coordinates coord { get; set; }
        public WeatherData[] weather { get; set; }
        public MainData main { get; set; }
        public String visibility { get; set; }
        public WindData wind { get; set; }
        public RainData rain { get; set; }
        public SnowData snow { get; set; }
        public CloudData clouds { get; set; }
        public long dt { get; set; }
        public SysData sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public String name { get; set; }
        public int cod { get; set; }
        public String message { get; set; }
    }

    public class RainData
    {
        [JsonProperty("1h")]
        public double hourly { get; set; }
        [JsonProperty("3h")]
        public double threehourly { get; set; }
    }

    public class SnowData
    {
        [JsonProperty("1h")]
        public double hourly { get; set; }
        [JsonProperty("3h")]
        public double threehourly { get; set; }
    }

public class Coordinates
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class WeatherData
    {
        public int id { get; set; }
        public String main { get; set; }
        public String description { get; set; }
        public String icon { get; set; }
    }

    public class MainData
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }

    }

    public class WindData
    {
        public double speed { get; set; }
        public double deg { get; set; }
        public double gust { get; set; }
    }

    public class CloudData
    {
        public int all { get; set; }
    }

    public class SysData
    {
        public int type { get; set; }
        public int id { get; set; }
        public String country { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }
}
