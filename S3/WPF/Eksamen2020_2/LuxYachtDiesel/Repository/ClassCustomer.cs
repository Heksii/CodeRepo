namespace Repository
{
    public class ClassCustomer : ClassNotify
    {
        #region Private Fields

        private string _address;

        private string _city;

        private ClassCountry _country;

        private int _Id;

        private string _mailAdr;

        private string _name;

        private string _phone;

        private string _postalCode;

        #endregion Private Fields

        #region Public Constructors

        public ClassCustomer()
        {
            address = "";
            city = "";
            country = new ClassCountry();
            Id = 0;
            mailAdr = "";
            name = "";
            phone = "";
            postalCode = "";
        }

        public ClassCustomer(ClassCustomer inCustomer)
        {
            address = inCustomer.address;
            city = inCustomer.city;
            country = inCustomer.country;
            Id = inCustomer.Id;
            mailAdr = inCustomer.mailAdr;
            name = inCustomer.name;
            phone = inCustomer.phone;
            postalCode = inCustomer.postalCode;
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

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
                Notify("name");
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