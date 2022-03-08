using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCurrency : ClassNotify
    {
        private Dictionary<string, string> _currencyIdName;
        private Dictionary<string, decimal> _rates;
        private Dictionary<string, string> _displayedRates;

        public ClassCurrency()
        {
            displayedRates = new Dictionary<string, string>();

            currencyIdName = new Dictionary<string, string>();
            rates = new Dictionary<string, decimal>();
        }

        public Dictionary<string, string> displayedRates
        {
            get { return _displayedRates; }
            set
            {
                if (_displayedRates != value)
                {
                    _displayedRates = value;
                }
                Notify("displayedRates");
            }
        }
        public Dictionary<string, decimal> rates
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
        public Dictionary<string, string> currencyIdName
        {
            get { return _currencyIdName; }
            set
            {
                if (_currencyIdName != value)
                {
                    _currencyIdName = value;
                }
                Notify("currencyIdName");
            }
        }

        public void SetValutaValueInProperty()
        {
            decimal dkk = rates["DKK"];
            foreach (string key in rates.Keys)
            {
                displayedRates.Add(key, (1 / rates[key] * dkk).ToString("##0.0000"));
            }
        }
    }
}
