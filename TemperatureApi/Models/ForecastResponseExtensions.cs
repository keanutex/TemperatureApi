using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Dtos;

namespace TemperatureApi.Models
{
    public static class ForecastResponseExtensions
    {
        public static WindDataDto ToWindDataDto(this ForecastResponse forecastResponse)
        {

            return new WindDataDto()
            {
                wind_mph = forecastResponse.current.wind_mph,
                wind_kph = forecastResponse.current.wind_kph,
                wind_degree = forecastResponse.current.wind_degree,
                wind_dir = forecastResponse.current.wind_dir
            };
        }

        public static PressureDataDto ToPressureDataDto(this ForecastResponse forecastResponse)
        {

            return new PressureDataDto()
            {
                pressure_mb = forecastResponse.current.pressure_mb,
                pressure_in = forecastResponse.current.pressure_in
            };
        }

        public static PrecipDataDto ToPrecipDataDto(this ForecastResponse forecastResponse)
        {

            return new PrecipDataDto()
            {
                precip_mm = forecastResponse.current.precip_mm,
                precip_in = forecastResponse.current.precip_in
            };
        }

        public static HumidityDataDto ToHumidityDataDto(this ForecastResponse forecastResponse)
        {

            return new HumidityDataDto()
            {
                humidity = forecastResponse.current.humidity
            };
        }

        public static SunriseDataDto ToSunriseDataDto(this ForecastResponse forecastResponse)
        {

            return new SunriseDataDto()
            {
                sunrise = forecastResponse.forecast.forecastday[0].astro.sunrise

                //for(ForecastDataDay in forecastResponse.forecast)
                //sunrises[]
               
            };
        }

        public static SunsetDataDto ToSunsetDataDto(this ForecastResponse forecastResponse)
        {

            return new SunsetDataDto()
            {
                sunset = forecastResponse.forecast.forecastday[0].astro.sunset

                //for(ForecastDataDay in forecastResponse.forecast)
                //sunrises[]

            };
        }
    }
}
