using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WeatherApp.Models;
using WeatherApp.Persistance;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public Forecast Weathers;

        private  IWeatherRepository _weatherRepository;

        private ObservableCollection<WeatherForView> _weatherList;
        public ObservableCollection<WeatherForView> WeatherList
        {
            get
            {
                return _weatherList;
            }
            set
            {
                _weatherList = value;
                OnPropertyChanged("WeatherList");
            }
        }

        public WeatherViewModel()
        {
            _weatherRepository = new WeatherRepository();
            WeatherDataAsync();
        }

        async void WeatherDataAsync()
        {
           // var repository = new WeatherRepository("Tunis");
            Weathers = await _weatherRepository.GetWeather("Tunis");
            WeatherList = PopulateList(Weathers);

        }

        ObservableCollection<WeatherForView> PopulateList(Forecast forecast)
        {
            var tempList = new ObservableCollection<WeatherForView>();

            var distinctDaysList = forecast.list
                                  .GroupBy(w => w.dt_txt.DayOfWeek)
                                  .Select(g => g.First())
                                  .ToList();

            foreach (var item in distinctDaysList)
            {
                var weatherForView = new WeatherForView
                {
                    Temp = KelvinToCelsius(double.Parse(item.main?.Temp, System.Globalization.CultureInfo.InvariantCulture)),
                    Date = item.dt_txt.ToString("dddd, dd"),
                    Description = item.weather?.FirstOrDefault().Description,
                    Icon = $"http://openweathermap.org/img/wn/{item.weather?.FirstOrDefault().Icon}@2x.png",
                    Humidity = $"{item.main?.humidity}%",
                    Pressure = $"{item.main?.pressure} hpa",
                    City = $"{forecast.City.Name}, {forecast.City.Country}",
                    Cloudiness= $"{item.Clouds?.All}%",
                    Wind= $"{item.Wind?.Speed} m/s"
                };
                tempList.Add(weatherForView);
            }

            return tempList;

        }

        double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
