using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class MainWeather : ClassNotify
    {
        // dt: long

        // coord: Coord
        // weather: List<Weather>
        // main: Main
        // wind: Wind
        // sys: Sys

        private long _dt;
        private string _updatedTime;
        private Coord _coord;
        private List<Weather> _weather;
        private Main _main;
        private Sys _sys;
        private Wind _wind;
        private Clouds _clouds;
        private long _timezone;
        private string _sunriseStr;
        private string _sunsetStr;
        private string _timezoneStr;

        public MainWeather()
        {
            dt = 0;
            updatedTime = "00:00:00";
            coord = new Coord();
            weather = new List<Weather>();
            main = new Main();
            sys = new Sys();
        }
        
        public string timezoneStr
        {
            get { return _timezoneStr; }
            set
            {
                if (_timezoneStr != value)
                {
                    _timezoneStr = value;
                }
                Notify("timezoneStr");
            }
        }
        public Clouds clouds
        {
            get { return _clouds; }
            set { _clouds = value; }
        }
        public long timezone
        {
            get { return _timezone; }
            set 
            { 
                if (_timezone != value)
                {
                    _timezone = value;

                    long osTimezone = (long)(DateTime.UtcNow - DateTime.Now).TotalSeconds;

                    sunriseStr = DateTimeFromUnixTime(sys.sunrise + timezone + osTimezone);
                    sunsetStr = DateTimeFromUnixTime(sys.sunset + timezone + osTimezone);
                    updatedTime = DateTimeFromUnixTime(dt + osTimezone);
                    timezoneStr = $"Tidszone: {TimezoneToString(timezone)}";
                }
            }
        }
        public long dt
        {
            get { return _dt; }
            set
            {
                if (_dt != value)
                {
                    _dt = value;
                }
            }
        }
        public string updatedTime
        {
            get { return _updatedTime; }
            set
            {
                if (_updatedTime != value)
                {
                    _updatedTime = value;
                }
                Notify("updatedTime");
            }
        }
        public Coord coord
        {
            get { return _coord; }
            set { _coord = value; }
        }
        public List<Weather> weather
        {
            get { return _weather; }
            set { _weather = value; }
        }
        public Main main
        {
            get { return _main; }
            set { _main = value; }
        }
        public Sys sys
        {
            get { return _sys; }
            set 
            { 
                _sys = value;
            }
        }
        public Wind wind
        {
            get { return _wind; }
            set { _wind = value; }
        }
        public string sunsetStr
        {
            get { return _sunsetStr; }
            set
            {
                if (_sunsetStr != value)
                {
                    _sunsetStr = value;
                }
                Notify("sunsetStr");
            }
        }
        public string sunriseStr
        {
            get { return _sunriseStr; }
            set
            {
                if (_sunriseStr != value)
                {
                    _sunriseStr = value;
                }
                Notify("sunriseStr");
            }
        }

        private string DateTimeFromUnixTime(long unixTime)
        {
            return new DateTime(1970, 1, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime).ToLocalTime().ToShortTimeString();
        }

        private string TimezoneToString(long inTimezone)
        {
            long gmtOffset = (long)Math.Round(inTimezone / 3600D);

            return $"GMT {(gmtOffset > 0 ? "+" : "")}{gmtOffset}";
        }
    }
}
