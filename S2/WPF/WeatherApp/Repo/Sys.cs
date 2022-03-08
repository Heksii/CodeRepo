using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class Sys : ClassNotify
    {
        private string _sunriseStr;
        private string _sunsetStr;

        private long _unixSunrise;
        private long _unixSunset;

        public Sys()
        {
            sunriseStr = "";
            sunsetStr = "";

            sunrise = 0L;
            sunset = 0L;
        }

        public long sunset
        {
            get { 
                return _unixSunset;
            }
            set
            {
                if (_unixSunset != value)
                {
                    _unixSunset = value;
                    sunsetStr = DateTimeFromUnixTime(sunset).ToShortTimeString();
                }
            }
        }
        public long sunrise
        {
            get { return _unixSunrise; }
            set
            {
                if (_unixSunrise != value)
                {
                    _unixSunrise = value;
                    sunriseStr = DateTimeFromUnixTime(sunrise).ToShortTimeString();
                }
            }
        }
        
        public string sunriseStr
        {
            get { return _sunriseStr; }
            private set
            {
                if (_sunriseStr != value)
                {
                    _sunriseStr = value;
                }
                Notify("sunriseStr");
            }
        }
        public string sunsetStr
        {
            get { return _sunsetStr; }
            private set
            {
                if (_sunsetStr != value)
                {
                    _sunsetStr = value;
                }
                Notify("sunsetStr");
            }
        }

        private DateTime DateTimeFromUnixTime(long unixTime)
        {
            return new DateTime(1970, 1, 1, 1, 0, 0, 0).AddSeconds(unixTime).ToLocalTime();
        }
    }
}
