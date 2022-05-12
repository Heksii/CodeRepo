using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Denne class har ansvaret for at holde valuta kurserne 
    /// som der modtages fra web API'en
    /// </summary>
    public class ClassApiRates
    {
        private long _timestamp;
        private Dictionary<string, double> _Rates;
        private string _newTimestamp;

        public ClassApiRates()
        {
            timestamp = 0L;
            Rates = new Dictionary<string, double>();
            newTimestamp = "";
        }

        public string newTimestamp
        {
            get { return _newTimestamp; }
            set { _newTimestamp = value; }
        }
        public Dictionary<string, double> Rates
        {
            get { return _Rates; }
            set { _Rates = value; }
        }
        public long timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }
    }
}
