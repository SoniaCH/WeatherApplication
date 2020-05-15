using System.Collections.Generic;

namespace WeatherApp.Models
{
    public class Forecast
    {
        public string Cod { get; set; }
        public City City { get; set; }
        public List<WeatherMainModel> list { get; set; }
    }
}
