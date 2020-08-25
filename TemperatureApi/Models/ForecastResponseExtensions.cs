using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Dtos;

namespace TemperatureApi.Models
{
    public static class ForecastResponseExtensions
    {
        public static List<WindDataDto> ToWindDataDto(this ForecastResponse forecastResponse)
        {
            var winds = forecastResponse.forecast.forecastday;
            List<WindDataDto> list = new List<WindDataDto>();

            foreach (ForecastDataDay w in winds)
            {
                WindDataDto x = new WindDataDto();
                x.date = w.date;
                x.maxwind_mph = w.day.maxwind_mph;
                x.maxwind_kph = w.day.maxwind_kph;
                //x.wind_mph = w.hour.wind_mph;
                //x.wind_kph = w.hour.wind_kph;
                //x.wind_degree = w.hour.wind_degree;
                //x.wind_dir = w.hour.wind_dir;
                //x.gust_mph = w.hour.gust_mph;
                //x.gust_kph = w.hour.gust_kph;
                list.Add(x);
            }
            return list;
        }

        public static List<PressureDataDto> ToPressureDataDto(this ForecastResponse forecastResponse)
        {
            var pressures = forecastResponse.forecast.forecastday;
            List<PressureDataDto> list = new List<PressureDataDto>();

            foreach (ForecastDataDay p in pressures)
            {
                PressureDataDto x = new PressureDataDto();
                x.date = p.date;
                x.pressure_mb = p.hour.pressure_mb;
                x.pressure_in = p.hour.pressure_in;
                list.Add(x);
            }
            return list;
        }

        public static List<PrecipitationDataDto> ToPrecipitationDataDto(this ForecastResponse forecastResponse)
        {
            var precipitations = forecastResponse.forecast.forecastday;
            List<PrecipitationDataDto> list = new List<PrecipitationDataDto>();

            foreach (ForecastDataDay p in precipitations)
            {
                PrecipitationDataDto x = new PrecipitationDataDto();
                x.date = p.date;
                x.totalprecip_mm = p.day.totalprecip_mm;
                x.totalprecip_in = p.day.totalprecip_in;
                //x.precip_mm = p.hour.precip_mm;
                //x.precip_in = p.hour.precip_in;
                list.Add(x);
            }
            return list;
        }

        public static List<HumidityDataDto> ToHumidityDataDto(this ForecastResponse forecastResponse)
        {
            var humidities = forecastResponse.forecast.forecastday;
            List<HumidityDataDto> list = new List<HumidityDataDto>();

            foreach (ForecastDataDay h in humidities)
            {
                HumidityDataDto x = new HumidityDataDto();
                x.date = h.date;
                x.humidity = h.hour.humidity;
                list.Add(x);
            }
            return list;
        }

        public static List<SunriseDataDto> ToSunriseDataDto(this ForecastResponse forecastResponse)
        {
            var sunrises = forecastResponse.forecast.forecastday;
            List<SunriseDataDto> list = new List<SunriseDataDto>();

            foreach (ForecastDataDay s in sunrises)
            {
                SunriseDataDto x = new SunriseDataDto();
                x.date = s.date;
                x.sunrise = s.astro.sunrise;
                list.Add(x);
            }
            return list;
        }

        public static List<SunsetDataDto> ToSunsetDataDto(this ForecastResponse forecastResponse)
        {
            var sunsets = forecastResponse.forecast.forecastday;
            List<SunsetDataDto> list = new List<SunsetDataDto>();

            foreach (ForecastDataDay s in sunsets)
            {
                SunsetDataDto x = new SunsetDataDto();
                x.date = s.date;
                x.sunset = s.astro.sunset;
                list.Add(x);
            }
            return list;
        }

        public static ElevationDataDto ToElevationDataDto(this ForecastResponse forecastResponse)
        {

            return new ElevationDataDto()
            {
                elevation = forecastResponse.forecast.forecastday[0].elevate.elevation

                //for(ForecastDataDay in forecastResponse.forecast)
                //sunrises[]

            };
        }
    }
}
