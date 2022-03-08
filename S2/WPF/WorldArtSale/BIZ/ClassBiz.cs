using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IO;
using Repository;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Windows;

namespace BIZ
{
    public class ClassBiz : ClassNotify
    {
        ClassJSONWebApiCall webApiCall = new ClassJSONWebApiCall();
        ClassWorldArtSaleDB artSaleDB = new ClassWorldArtSaleDB();
        ClassFileIO fileHandler = new ClassFileIO();

        private ClassArt _classArt;
        private ClassArt _editArt;
        private List<ClassArt> _listClassArt;
        private List<ClassCountry> _countryList;
        private ClassCurrency _classCurrency;
        private List<ClassCountry> _listCurrency;
        private ClassCustomer _classCustomer;
        private ClassCustomer _editCustomer;
        private List<ClassCustomer> _listCustomer;
        private ClassSalesValue _classSalesValue;
        private bool _topLeftEnabled;
        private bool _topMiddleEnabled;
        private bool _topRightEnabled;

        public ClassBiz()
        {
            classSalesValue = new ClassSalesValue();
            classArt = new ClassArt();
            listClassArt = new List<ClassArt>();
            classCustomer = new ClassCustomer();
            listCustomer = new List<ClassCustomer>();
            classCurrency = new ClassCurrency();
            countryList = new List<ClassCountry>();
            listCurrency = new List<ClassCountry>();
            editCustomer = new ClassCustomer();
            editArt = new ClassArt();

            topLeftEnabled = true;
            topRightEnabled = false;
            topMiddleEnabled = false;

            GetAllCurrencyAndNames();
            GetAllCustomers();
            GetAllArt();
        }

        public bool topRightEnabled
        {
            get { return _topRightEnabled; }
            set
            {
                if (_topRightEnabled != value)
                {
                    _topRightEnabled = value;
                }
                Notify("topRightEnabled");
            }
        }
        public bool topMiddleEnabled
        {
            get { return _topMiddleEnabled; }
            set
            {
                if (_topMiddleEnabled != value)
                {
                    _topMiddleEnabled = value;
                }
                Notify("topMiddleEnabled");
            }
        }
        public bool topLeftEnabled
        {
            get { return _topLeftEnabled; }
            set
            {
                if (_topLeftEnabled != value)
                {
                    _topLeftEnabled = value;
                }
                Notify("topLeftEnabled");
            }
        }

        public ClassSalesValue classSalesValue
        {
            get { return _classSalesValue; }
            set
            {
                if (_classSalesValue != value)
                {
                    _classSalesValue = value;
                }
                Notify("classSalesValue");
            }
        }
        public List<ClassCountry> countryList
        {
            get { return _countryList; }
            set
            {
                if (_countryList != value)
                {
                    _countryList = value;
                }
                Notify("countryList");
            }
        }

        public ClassArt classArt
        {
            get { return _classArt; }
            set
            {
                if (_classArt != value)
                {
                    _classArt = value;

                    topRightEnabled = value.artID > 0 && classCustomer.customerID > 0;
                }
                Notify("classArt");
            }
        }
        public ClassArt editArt
        {
            get { return _editArt; }
            set
            {
                if (_editArt != value)
                {
                    _editArt = value;
                }
                Notify("editArt");
            }
        }
        public List<ClassArt> listClassArt
        {
            get { return _listClassArt; }
            set
            {
                if (_listClassArt != value)
                {
                    _listClassArt = value;
                }
                Notify("listClassArt");
            }
        }

        public List<ClassCountry> listCurrency
        {
            get { return _listCurrency; }
            set
            {
                if (_listCurrency != value)
                {
                    _listCurrency = value;
                }
                Notify("listCurrency");
            }
        }
        public ClassCurrency classCurrency
        {
            get { return _classCurrency; }
            set
            {
                if (_classCurrency != value)
                {
                    _classCurrency = value;
                    if (value.rates.Count > 0)
                    {
                        classCurrency.SetValutaValueInProperty();
                        classSalesValue.classCurrency.rates = classCurrency.rates;
                        classSalesValue.customerValutaCode = classCustomer.customerValutaCode;
                        classSalesValue.SetBidOnArt();
                    }
                }
                Notify("classCurrency");
            }
        }

        public ClassCustomer classCustomer
        {
            get { return _classCustomer; }
            set
            {
                if (_classCustomer != value)
                {
                    _classCustomer = value;
                    classSalesValue.customerValutaCode = classCustomer.customerCurrencyData.code;

                    topMiddleEnabled = value.customerID > 0;
                }
                Notify("classCustomer");
            }
        }
        public ClassCustomer editCustomer
        {
            get { return _editCustomer; }
            set
            {
                if (_editCustomer != value)
                {
                    _editCustomer = value;
                }
                Notify("editCustomer");
            }
        }
        public List<ClassCustomer> listCustomer
        {
            get { return _listCustomer; }
            set
            {
                if (_listCustomer != value)
                {
                    _listCustomer = value;
                }
                Notify("listCustomer");
            }
        }

        public async Task StartCurrencyApiCall()
        {
            try
            {
                while (true) {
                    string strJson = await webApiCall.GetURLContentAsync("https://openexchangerates.org/api/latest.json?app_id=2cb05a5bf7804828b118ddd3e58a2e60&base=USD");
                    classCurrency = JsonConvert.DeserializeObject<ClassCurrency>(strJson);

                    await Task.Delay(600000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "API Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void GetAllCurrencyAndNames()
        {
            countryList = artSaleDB.GetCountryData();
            listCurrency = artSaleDB.GetValutaData();
            if (countryList.Count <= 0)
            {
                foreach (ClassCountry country in fileHandler.ReadCountryDataFromCsvFile())
                {
                    artSaleDB.InsertCountryInDB(country);
                }
                GetAllCurrencyAndNames();
            }
        }
        
        public void UpdateCustomer()
        {
            artSaleDB.UpdateCustomerInDB(editCustomer);
            classCustomer.name = editCustomer.name;
            classCustomer.adress = editCustomer.adress;
            classCustomer.zipCity = editCustomer.zipCity;
            classCustomer.country = editCustomer.country;
            classCustomer.email = editCustomer.email;
            classCustomer.phoneNo = editCustomer.phoneNo;
            classCustomer.customerCurrencyData = editCustomer.customerCurrencyData;
            classCustomer.maxBid = editCustomer.maxBid;
            classCustomer.isActive = editCustomer.isActive;

            editCustomer = new ClassCustomer();
        }
        public void AddNewCustomer()
        {
            int newID = artSaleDB.InsertCustomerInDB(editCustomer);
            GetAllCustomers();
            foreach (ClassCustomer tempCust in listCustomer)
            {
                if (tempCust.customerID == newID)
                {
                    classCustomer = tempCust;
                }
            }
        }
        private void GetAllCustomers()
        {
            listCustomer = artSaleDB.GetAllCustomerFromDB();
        }

        public void UpdateArt()
        {
            artSaleDB.UpdateArtInDB(editArt);
            classArt.artID = editArt.artID;
            classArt.pictureTitle = editArt.pictureTitle;
            classArt.pictureDescription = editArt.pictureDescription;
            classArt.picturePath = editArt.picturePath;
            classArt.isActive = editArt.isActive;

            editArt = new ClassArt();
        }
        public void AddNewArt()
        {
            int newID = artSaleDB.InsertArtInDB(editArt);
            GetAllArt();
            foreach (ClassArt tempArt in listClassArt)
            {
                if (tempArt.artID == newID)
                {
                    classArt = tempArt;
                }
            }
        }
        private void GetAllArt()
        {
            listClassArt = artSaleDB.GetAllArtFromDB();
        }
    }
}
