using System;
using System.Collections.Generic;
using System.Linq;
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

                // WILL ADD IF THERE IS TIME:
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

        // WILL ADD IF THERE IS TIME:
        //public static List<WindDataDto> ToWindDataDto(this ForecastResponse forecastResponse)
        //{
        //    var winds = forecastResponse.forecast.forecastday;
        //    List<WindDataDto> list = new List<WindDataDto>();

        //    foreach (ForecastDataDay w in winds)
        //    {
        //        WindDataDto x = new WindDataDto();
        //        x.date = w.date;
        //        x.maxwind_mph = w.day.maxwind_mph;
        //        x.maxwind_kph = w.day.maxwind_kph;
        //        //x.wind_mph = w.hour.wind_mph;
        //        //x.wind_kph = w.hour.wind_kph;
        //        //x.wind_degree = w.hour.wind_degree;
        //        //x.wind_dir = w.hour.wind_dir;
        //        //x.gust_mph = w.hour.gust_mph;
        //        //x.gust_kph = w.hour.gust_kph;
        //        list.Add(x);
        //    }
        //    return list;
        //}


        public static AvgWindDataDto ToAvgWindDataDto(this ForecastResponse forecastResponse)
        {
            var avgMaxWind_kph = 0.0;
            var avgMaxWind_mph = 0.0;

            foreach (var forecastDataDay in forecastResponse.forecast.forecastday)
            {
                avgMaxWind_kph += forecastDataDay.day.maxwind_kph;
                avgMaxWind_mph += forecastDataDay.day.maxwind_mph;
            }

            avgMaxWind_kph /= forecastResponse.forecast.forecastday.Length;
            avgMaxWind_mph /= forecastResponse.forecast.forecastday.Length;

            return new AvgWindDataDto() 
            { 
                DateFrom = forecastResponse.forecast.forecastday.FirstOrDefault().date,
                DateTo = forecastResponse.forecast.forecastday.LastOrDefault().date,
                NumberOfDays = forecastResponse.forecast.forecastday.Length,
                AvgMaxwind_kph = Math.Round(avgMaxWind_kph,2),
                AvgMaxwind_mph = Math.Round(avgMaxWind_mph,2)
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

        //public static List<PressureDataDto> ToPressureDataDto(this ForecastResponse forecastResponse)
        //{
        //    var pressures = forecastResponse.forecast.forecastday;
        //    List<PressureDataDto> list = new List<PressureDataDto>();

        //    foreach (ForecastDataDay p in pressures)
        //    {
        //        PressureDataDto x = new PressureDataDto();
        //        x.date = p.date;
        //        x.pressure_mb = p.hour.pressure_mb;
        //        x.pressure_in = p.hour.pressure_in;
        //        list.Add(x);
        //    }
        //    return list;
        //}

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

        public static AvgPrecipitationDataDto ToAvgPrecipitationDataDto(this ForecastResponse forecastResponse)
        {
            var avgtotalprecip_mm = 0.0;
            var avgtotalprecip_in = 0.0;

            foreach (var dayData in forecastResponse.forecast.forecastday)
            {
                avgtotalprecip_mm += dayData.day.totalprecip_mm;
                avgtotalprecip_in += dayData.day.totalprecip_in;
            }

            avgtotalprecip_mm /= forecastResponse.forecast.forecastday.Length;
            avgtotalprecip_in /= forecastResponse.forecast.forecastday.Length;

            return new AvgPrecipitationDataDto()
            {
                DateFrom = forecastResponse.forecast.forecastday.FirstOrDefault().date,
                DateTo = forecastResponse.forecast.forecastday.LastOrDefault().date,
                NumberOfDays = forecastResponse.forecast.forecastday.Length,
                AvgTotalprecip_mm = Math.Round(avgtotalprecip_mm,2),
                AvgTotalprecip_in = Math.Round(avgtotalprecip_in,2)
            };
        }

        public static List<HumidityDataDto> ToHumidityDataDto(this ForecastResponse forecastResponse)
        {
            var humidities = forecastResponse.forecast.forecastday;
            List<HumidityDataDto> list = new List<HumidityDataDto>();

            foreach (ForecastDataDay h in humidities)
            {
                HumidityDataDto x = new HumidityDataDto();
                x.date = h.date;
                x.humidity_percentage = h.day.avghumidity;
                list.Add(x);
            }
            return list;
        }

        public static AvgHumidityDataDto ToAvgHumidityDataDto(this ForecastResponse forecastResponse)
        {
            var avghumidity = 0.0;

            foreach (var dayData in forecastResponse.forecast.forecastday)
            {
                avghumidity += dayData.day.avghumidity;
            }

            avghumidity /= forecastResponse.forecast.forecastday.Length;

            return new AvgHumidityDataDto()
            {
                DateFrom = forecastResponse.forecast.forecastday.FirstOrDefault().date,
                DateTo = forecastResponse.forecast.forecastday.LastOrDefault().date,
                NumberOfDays = forecastResponse.forecast.forecastday.Length,
                AvgHumidity_percentage = Math.Round(avghumidity, 2)
            };
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

        public static AvgSunriseDataDto ToAvgSunriseDataDto(this ForecastResponse forecastResponse)
        {
            var dates = forecastResponse.forecast.forecastday;
            var count = dates.Length;
            double temp = 0D;
            
            for (int i = 0; i < count; i++)
            {
                DateTime cur = Convert.ToDateTime(dates[i].astro.sunrise);
                temp += cur.Ticks / (double)count;
            }
            var average = new DateTime((long)temp);

            return new AvgSunriseDataDto()
            {
                DateFrom = forecastResponse.forecast.forecastday.FirstOrDefault().date,
                DateTo = forecastResponse.forecast.forecastday.LastOrDefault().date,
                NumberOfDays = forecastResponse.forecast.forecastday.Length,
                AvgSunrise = average.TimeOfDay.ToString()
            };
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

        public static AvgSunsetDataDto ToAvgSunsetDataDto(this ForecastResponse forecastResponse)
        {
            var dates = forecastResponse.forecast.forecastday;
            var count = dates.Length;
            double temp = 0D;

            for (int i = 0; i < count; i++)
            {
                DateTime cur = Convert.ToDateTime(dates[i].astro.sunset);
                temp += cur.Ticks / (double)count;
            }
            var average = new DateTime((long)temp);

            return new AvgSunsetDataDto()
            {
                DateFrom = forecastResponse.forecast.forecastday.FirstOrDefault().date,
                DateTo = forecastResponse.forecast.forecastday.LastOrDefault().date,
                NumberOfDays = forecastResponse.forecast.forecastday.Length,
                AvgSunset = average.TimeOfDay.ToString()
            };
        }
    }
}
