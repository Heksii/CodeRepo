using IO;
using Repository;
using System.Collections.Generic;
using System.Windows;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {

        #region Private Fields

        private ClassCallWebAPI _classCallWebAPI;
        private ClassLuxYachtDieselDB _classLuxYachtDieselDB;
        private ClassCountry _country;
        private ClassCurrency _currency;
        private ClassDieselPrice _dieselPrice;
        private List<ClassDieselPrice> _dieselPriceList;
        private ClassCustomer _fallbackCustomer;
        private ClassSupplier _fallbackSupplier;
        private bool _isEditingCustomer;
        private bool _isEditingCustomerInv;
        private List<ClassCountry> _listCountries;
        private List<ClassCustomer> _listCustomers;
        private List<ClassSupplier> _listSuppliers;
        private ClassOrder _order;
        private ClassCustomer _selectedCustomer;
        private ClassSupplier _selectedSupplier;

        #endregion Private Fields

        #region Public Constructors

        public ClassBIZ()
        {
            classCallWebAPI = new ClassCallWebAPI();
            classLuxYachtDieselDB = new ClassLuxYachtDieselDB();
            country = new ClassCountry();
            currency = new ClassCurrency();
            dieselPrice = new ClassDieselPrice();
            fallbackCustomer = new ClassCustomer();
            fallbackSupplier = new ClassSupplier();
            listCustomers = new List<ClassCustomer>();
            listSuppliers = new List<ClassSupplier>();
            order = new ClassOrder();
            selectedCustomer = new ClassCustomer();
            selectedSupplier = new ClassSupplier();
            listCountries = new List<ClassCountry>();
            isEditingCustomer = false;

            listCustomers = GetAllCustomerForListFromDB();
            listCountries = classLuxYachtDieselDB.GetAllCountriesFromDB();

            dieselPriceList = classLuxYachtDieselDB.GetAllOilPriceFromDB();
            GetApiRates();
        }

        #endregion Public Constructors

        #region Public Properties

        public ClassCallWebAPI classCallWebAPI
        {
            get
            {
                return _classCallWebAPI;
            }
            set
            {
                if (_classCallWebAPI != value)
                {
                    _classCallWebAPI = value;
                }
                Notify("classCallWebAPI");
            }
        }

        public ClassLuxYachtDieselDB classLuxYachtDieselDB
        {
            get
            {
                return _classLuxYachtDieselDB;
            }
            set
            {
                if (_classLuxYachtDieselDB != value)
                {
                    _classLuxYachtDieselDB = value;
                }
                Notify("classLuxYachtDieselDB");
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

        public ClassCurrency currency
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

        public ClassDieselPrice dieselPrice
        {
            get
            {
                return _dieselPrice;
            }
            set
            {
                if (_dieselPrice != value)
                {
                    _dieselPrice = value;
                }
                Notify("dieselPrice");
            }
        }

        public List<ClassDieselPrice> dieselPriceList
        {
            get { return _dieselPriceList; }
            set
            {
                if (_dieselPriceList != value)
                {
                    _dieselPriceList = value;
                }
                Notify("dieselPriceList");
            }
        }

        public ClassCustomer fallbackCustomer
        {
            get
            {
                return _fallbackCustomer;
            }
            set
            {
                if (_fallbackCustomer != value)
                {
                    _fallbackCustomer = value;
                }
                Notify("fallbackCustomer");
            }
        }

        public ClassSupplier fallbackSupplier
        {
            get
            {
                return _fallbackSupplier;
            }
            set
            {
                if (_fallbackSupplier != value)
                {
                    _fallbackSupplier = value;
                }
                Notify("fallbackSupplier");
            }
        }

        public bool isEditingCustomer
        {
            get { return _isEditingCustomer; }
            set
            {
                if (_isEditingCustomer != value)
                {
                    _isEditingCustomer = value;
                }

                isEditingCustomerInv = !isEditingCustomer;
                Notify("isEditingCustomer");
            }
        }

        public bool isEditingCustomerInv
        {
            get { return _isEditingCustomerInv; }
            set
            {
                if (_isEditingCustomerInv != value)
                {
                    _isEditingCustomerInv = value;
                }
                Notify("isEditingCustomerInv");
            }
        }

        public List<ClassCountry> listCountries
        {
            get { return _listCountries; }
            set
            {
                if (_listCountries != value)
                {
                    _listCountries = value;
                }
                Notify("listCountries");
            }
        }
        public List<ClassCustomer> listCustomers
        {
            get
            {
                return _listCustomers;
            }
            set
            {
                if (_listCustomers != value)
                {
                    _listCustomers = value;
                }
                Notify("listCustomers");
            }
        }

        public List<ClassSupplier> listSuppliers
        {
            get
            {
                return _listSuppliers;
            }
            set
            {
                if (_listSuppliers != value)
                {
                    _listSuppliers = value;
                }
                Notify("listSuppliers");
            }
        }

        public ClassOrder order
        {
            get
            {
                return _order;
            }
            set
            {
                if (_order != value)
                {
                    _order = value;
                }
                Notify("order");
            }
        }

        public ClassCustomer selectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                }
                Notify("selectedCustomer");
            }
        }

        public ClassSupplier selectedSupplier
        {
            get
            {
                return _selectedSupplier;
            }
            set
            {
                if (_selectedSupplier != value)
                {
                    _selectedSupplier = value;
                }
                Notify("selectedSupplier");
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void CalculateAllValuesForOrder()
        {
        }

        public ClassCountry GetAllCountrysWebAPI()
        {
            ClassCountry cc = new ClassCountry();

            return cc;
        }

        public List<ClassCustomer> GetAllCustomerForListFromDB()
        {
            List<ClassCustomer> cc = new List<ClassCustomer>();

            cc = classLuxYachtDieselDB.GetAllCustomersFromDB();

            listCustomers = cc;
            //selectedCustomer = listCustomers[0];

            return cc;
        }

        public List<ClassSupplier> GetAllSuppliersForListFromDB()
        {
            List<ClassSupplier> cc = new List<ClassSupplier>();

            return cc;
        }

        public ClassDieselPrice GetDieselPriceFromDB()
        {
            ClassDieselPrice cdp = new ClassDieselPrice();

            return cdp;
        }

        public void InsertDieselPriceInDB()
        {
            classLuxYachtDieselDB.InsertOilPriceInDB(dieselPrice);
            dieselPriceList = classLuxYachtDieselDB.GetAllOilPriceFromDB();
        }

        public void InsertOrderInDB()
        {
        }

        public void RegretNewDieselPriceForDB()
        {
        }

        public void RegretNewOrderForDB()
        {
        }

        public void RegretUpdateOrNewCustomerForDB()
        {
        }

        public void RegretUpdateOrNewSupplierForDB()
        {
        }

        public void UpdateOrInsertCustomerInDB()
        {
            if (selectedCustomer.Id != 0)
            {
                classLuxYachtDieselDB.UpdateCustomerInDB(selectedCustomer);
            }
            else
            {
                classLuxYachtDieselDB.InsertCustomerInDB(selectedCustomer);
            }

            listCustomers = classLuxYachtDieselDB.GetAllCustomersFromDB();
        }

        public void UpdateOrInsertSupplierInDB()
        {
        }

        #endregion Public Methods

        #region Private Methods

        private async void GetApiRates()
        {
            currency = await classCallWebAPI.GetRatesFromWebApi();
        }

        #endregion Private Methods

    }
}