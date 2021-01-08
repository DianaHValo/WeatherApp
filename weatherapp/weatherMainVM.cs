using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace weatherapp
{
    public class weatherMainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string celsiusv;
        private string _unit;
        public ICommand LoadWeatherCommand { get; set; }

        public string clouds { get; set; }
        public string wind { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
        public string celsius { get; set; }

        public string UserInput { get; set; }

        public string Unit
        {
            get { return _unit; }
            set
            {
                if (celsiusv != null)
                {
                    if (value.Contains("Farenheit"))
                    {
                        celsius = calculateFarenheit(celsiusv).ToString();
                    }
                    else if (value.Contains("Celsius"))
                    {
                        celsius = celsiusv;
                    }
                    RaisePropertyChange(nameof(celsius));
                }
            }
        }

        public weatherMainVM()
        {
            weatherModel model = new weatherModel();
            LoadWeatherCommand = new CommandHandler(LoadWeather, CanExecute);
        }

        protected void RaisePropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public async void LoadWeather()
        {   
            
            weatherModel w = new weatherModel();
            try
            {
                var result = await w.LoadWeatherInfo(UserInput);
                clouds = result.clouds.All;
                RaisePropertyChange(nameof(clouds));
                wind = result.wind.Speed;
                RaisePropertyChange(nameof(wind));
                pressure = result.main.Pressure;
                RaisePropertyChange(nameof(pressure));
                humidity = result.main.Humidity;
                RaisePropertyChange(nameof(humidity));
                celsius = result.main.Temp;
                celsiusv = result.main.Temp;
                RaisePropertyChange(nameof(celsius));
            }
            catch
            {
                MessageBox.Show("City name not found!");
            }
        }

        private double calculateFarenheit(string degreesToConvert)
        {
            double farenheit;
            double degrees = Convert.ToDouble(degreesToConvert);

            farenheit = degrees * 9 / 5 + 32;
            return farenheit;
        }

        public bool CanExecute()
        {
            return true;
        }

        
    }
}
