using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Repo
{
    public class ExchangeRates : ClassNotify
    {
        //Fields
        private string _disclaimer;
        private string _license;
        private long _timestamp;
        private string _based;
        private Dictionary<string, double> _rates;
        private string _stringDateTime;

        //Constructors
        public ExchangeRates()
        {
            disclaimer = "";
            license = "";
            timestamp = 0L;
            based = "";
            rates = new Dictionary<string, double>();
        }

        //Properties
        public string disclaimer
        {
            get { return _disclaimer; }
            set
            {
                if (_disclaimer != value)
                {
                    _disclaimer = value;
                }
                Notify("disclaimer");
            }
        }
        public string license
        {
            get { return _license; }
            set
            {
                if (_license != value)
                {
                    _license = value;
                }
                Notify("license");
            }
        }
        public long timestamp
        {
            get { return _timestamp; }
            set
            {
                if (_timestamp != value)
                {
                    _timestamp = value;
                    MakeTimeString();
                }
                Notify("timestamp");
            }
        }
        
        [JsonProperty(PropertyName = "base")]
        public string based
        {
            get { return _based; }
            set
            {
                if (_based != value)
                {
                    _based = value;
                }
                Notify("based");
            }
        }
        public Dictionary<string, double> rates
        {
            get { return _rates; }
            set
            {
                if (_rates != value)
                {
                    _rates = value;
                }
                Notify("rates");
            }
        }

        public string stringDateTime
        {
            get { return _stringDateTime; }
            set
            {
                if (_stringDateTime != value)
                {
                    _stringDateTime = value;
                }
                Notify("stringDateTime");
            }
        }
        private void MakeTimeString()
        {
            
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();
            stringDateTime = dateTime.ToString("yyyy-MM-dd  HH:mm:ss");
        }
    }
}

