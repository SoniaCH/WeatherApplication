using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class WeatherForView
    {
        public double Temp { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
        public string Cloudiness { get; set; }
        public string Wind { get; set; }

    }
}
