using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Persistance
{
    public class WeatherRepository: IWeatherRepository
    {
        private string url;
        public WeatherRepository()
        {
        }

        public async Task<Forecast> GetWeather(string city)
        {
            try
            {
                url = ApiSettings.GetUrl(city);
                Forecast weather = null;
                using (var client = new HttpClient())
                {
                    var json = await client.GetStringAsync(url);
                    await Task.Run(() =>
                    {
                        weather = JsonConvert.DeserializeObject<Forecast>(json);
                    });

                }
                return weather;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }




}
