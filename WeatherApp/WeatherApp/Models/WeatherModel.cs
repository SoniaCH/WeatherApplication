using System;
using System.Collections.Generic;

namespace WeatherApp.Models
{
    public class WeatherModel
   {
        public string Temp { get; set; }
        public string humidity { get; set; }
        public string pressure { get; set; }
   }
    public class WeatherMainModel
    {
        public string dt { get; set; }
        public WeatherModel main { get; set; }
        public DateTime dt_txt { get; set; }
        public List<Weather> weather { get; set; }
        public Cloud Clouds { get; set; }
        public Wind Wind { get; set; }
    }
}
