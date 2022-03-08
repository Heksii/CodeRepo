using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCustomer : ClassSalesValue
    {
        private int _customerID;
        private string _name;
        private string _adress;
        private string _zipCity;
        private string _country;
        private string _email;
        private string _phoneNo;
        private ClassCountry _customerCurrencyData;
        private double _maxBid;
        private bool _isActive;

        public ClassCustomer()
        {
            customerID = 0;
            name = "";
            adress = "";
            zipCity = "";
            country = "";
            email = "";
            phoneNo = "";
            customerCurrencyData = new ClassCountry();
            maxBid = 0D;
            isActive = true;
        }
        public ClassCustomer(ClassCustomer inCustomer)
        {
            customerID = inCustomer.customerID;
            name = inCustomer.name;
            adress = inCustomer.adress;
            zipCity = inCustomer.zipCity;
            country = inCustomer.country;
            email = inCustomer.email;
            phoneNo = inCustomer.phoneNo;
            customerCurrencyData = inCustomer.customerCurrencyData;
            maxBid = inCustomer.maxBid;
            isActive = inCustomer.isActive;
        }

        

        public bool isActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                }
                Notify("isActive");
            }
        }
        public double maxBid
        {
            get { return _maxBid; }
            set
            {
                if (_maxBid != value)
                {
                    _maxBid = value;
                }
                Notify("maxBid");
            }
        }
        public ClassCountry customerCurrencyData
        {
            get { return _customerCurrencyData; }
            set
            {
                if (_customerCurrencyData != value)
                {
                    _customerCurrencyData = value;
                }
                Notify("customerCurrencyData");
            }
        }
        public string phoneNo
        {
            get { return _phoneNo; }
            set
            {
                if (_phoneNo != value)
                {
                    _phoneNo = value;
                }
                Notify("phoneNo");
            }
        }
        public string email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                }
                Notify("email");
            }
        }
        public string country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                }
                Notify("country");
            }
        }
        public string zipCity
        {
            get { return _zipCity; }
            set
            {
                if (_zipCity != value)
                {
                    _zipCity = value;
                }
                Notify("zipCity");
            }
        }
        public string adress
        {
            get { return _adress; }
            set
            {
                if (_adress != value)
                {
                    _adress = value;
                }
                Notify("adress");
            }
        }
        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
                Notify("name");
            }
        }
        public int customerID
        {
            get { return _customerID; }
            set
            {
                if (_customerID != value)
                {
                    _customerID = value;
                }
                Notify("customerID");
            }
        }
    }
}
