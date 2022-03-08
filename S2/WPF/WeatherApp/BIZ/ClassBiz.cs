using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo;
using IO;
using Newtonsoft.Json;

namespace BIZ
{
    public class ClassBiz : ClassNotify
    {
        private ClassJSONWebApiCall apiCall;
        private string _cityName;
        private MainWeather _weather;

        public ClassBiz()
        {
            weather = new MainWeather();
            apiCall = new ClassJSONWebApiCall();
        }
        
        public MainWeather weather
        {
            get { return _weather; }
            set
            {
                if (_weather != value)
                {
                    _weather = value;
                }
                Notify("weather");
            }
        }
        public string cityName
        {
            get { return _cityName; }
            set
            {
                if (_cityName != value)
                {
                    _cityName = value;
                }
                Notify("cityName");
            }
        }
        public async Task StartWeatherApiCall()
        {
            byte[] urlContect = await apiCall.GetURLContentAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=30df1b5995c9bc84d8bb98924e226279&lang=da");

            string strJson = Encoding.UTF8.GetString(urlContect);
            weather = JsonConvert.DeserializeObject<MainWeather>(strJson);
        }
    }
}
