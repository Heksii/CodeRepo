using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCountry : ClassNotify
    {
        #region Private Fields

        private string _country;

        private string _currency;

        private string _currencyCode;

        private int _Id;

        #endregion Private Fields

        #region Public Constructors

        public ClassCountry()
        {
            country = "";
            currency = "";
            currencyCode = "";
            Id = 0;
        }

        #endregion Public Constructors

        #region Public Properties

        public string country
        {
            get
            {
                return _country;
            }
            set
            {
                if (_country != value)
                {
                    _country = value;
                }
                Notify("country");
            }
        }

        public string currency
        {
            get
            {
                return _currency;
            }
            set
            {
                if (_currency != value)
                {
                    _currency = value;
                }
                Notify("currency");
            }
        }

        public string currencyCode
        {
            get
            {
                return _currencyCode;
            }
            set
            {
                if (_currencyCode != value)
                {
                    _currencyCode = value;
                }
                Notify("currencyCode");
            }
        }

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                }
                Notify("Id");
            }
        }

        #endregion Public Properties
    }
}