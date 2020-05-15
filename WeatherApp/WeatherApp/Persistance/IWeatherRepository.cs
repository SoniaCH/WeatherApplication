using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Persistance
{
    public interface IWeatherRepository
    {
        Task<Forecast> GetWeather(string city);
    }
}
