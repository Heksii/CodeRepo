using System.Collections.Generic;
using Newtonsoft.Json;

namespace Repository
{
    public class ClassCurrency : ClassNotify
    {
        #region Private Fields

        private string _Base;

        private string _disclaimer;

        private string _license;

        private long _timestamp;

        private Dictionary<string, decimal> _rates;

        #endregion Private Fields

        #region Public Constructors

        public ClassCurrency()
        {
            Base = "";
            disclaimer = "";
            license = "";
            timestamp = 0L;
            rates = new Dictionary<string, decimal>();
        }

        #endregion Public Constructors

        #region Public Properties

        [JsonProperty("base")]
        public string Base
        {
            get
            {
                return _Base;
            }
            set
            {
                if (_Base != value)
                {
                    _Base = value;
                }
                Notify("Base");
            }
        }

        public string disclaimer
        {
            get
            {
                return _disclaimer;
            }
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
            get
            {
                return _license;
            }
            set
            {
                if (_license != value)
                {
                    _license = value;
                }
                Notify("license");
            }
        }

        public Dictionary<string, decimal> rates
        {
            get
            {
                return _rates;
            }
            set
            {
                if (_rates != value)
                {
                    _rates = value;
                }
                Notify("rates");
            }
        }

        public long timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                if (_timestamp != value)
                {
                    _timestamp = value;
                }
                Notify("timestamp");
            }
        }

        #endregion Public Properties
    }
}