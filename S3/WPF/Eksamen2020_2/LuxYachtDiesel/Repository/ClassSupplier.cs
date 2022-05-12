using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassSupplier : ClassNotify
    {
        #region Private Fields

        private string _address;

        private string _city;

        private string _contactName;

        private ClassCountry _country;

        private string _firmName;

        private int _Id;

        private string _mailAdr;

        private string _phone;

        private string _postalCode;

        #endregion Private Fields

        #region Public Constructors

        public ClassSupplier()
        {
            Id = 0;
            firmName = "";
            contactName = "";
            address = "";
            city = "";
            postalCode = "";
            country = new ClassCountry();
            phone = "";
            mailAdr = "";
        }

        #endregion Public Constructors

        #region Public Properties

        public string address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address != value)
                {
                    _address = value;
                }
                Notify("address");
            }
        }

        public string city
        {
            get
            {
                return _city;
            }
            set
            {
                if (_city != value)
                {
                    _city = value;
                }
                Notify("city");
            }
        }

        public string contactName
        {
            get
            {
                return _contactName;
            }
            set
            {
                if (_contactName != value)
                {
                    _contactName = value;
                }
                Notify("contactName");
            }
        }

        public ClassCountry country
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

        public string firmName
        {
            get
            {
                return _firmName;
            }
            set
            {
                if (_firmName != value)
                {
                    _firmName = value;
                }
                Notify("firmName");
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

        public string mailAdr
        {
            get
            {
                return _mailAdr;
            }
            set
            {
                if (_mailAdr != value)
                {
                    _mailAdr = value;
                }
                Notify("mailAdr");
            }
        }

        public string phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                }
                Notify("phone");
            }
        }

        public string postalCode
        {
            get
            {
                return _postalCode;
            }
            set
            {
                if (_postalCode != value)
                {
                    _postalCode = value;
                }
                Notify("postalCode");
            }
        }

        #endregion Public Properties
    }
}