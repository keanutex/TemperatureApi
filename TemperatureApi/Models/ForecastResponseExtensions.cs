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
    }
}
