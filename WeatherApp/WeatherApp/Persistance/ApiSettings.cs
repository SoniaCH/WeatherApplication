namespace WeatherApp.Persistance
{
    public class ApiSettings
    {


        public static string GetUrl(string city)
        {
            string apiKey = "a86e4b6c15c3c07928f0732d0f3c805b";
            //return $"api.openweathermap.org/data/2.5/weather?q={city}";
            return $"http://api.openweathermap.org/data/2.5/forecast?q={city}&APPID={apiKey}";
            //return $"api.openweathermap.org/data/2.5/forecast?q={city}&APPID={apiKey}";
        }
        //api.openweathermap.org/data/2.5/forecast?q={city name}&appid={your api key}
    }
}
