using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Nito.AsyncEx;
using Repository;

namespace BIZ
{
    /// <summary>
    /// Denne class har ansvaret for alt bagvedliggende arbejde
    /// som programmet skal fortage sig, 
    /// den indeholder også alle værdierne som brugergrænsefladen bindes til.
    /// </summary>
    public class ClassBiz : ClassNotify
    {
        ClassCallWebAPI ccwa = new ClassCallWebAPI();
        ClassMeatGrossDB cmgdb = new ClassMeatGrossDB();

        private List<ClassCustomer> _listCustomer;
        private List<ClassCountry> _listCountry;
        private List<ClassMeat> _listMeat;
        private ClassApiRates _apiRates;
        private ClassCustomer _selectedCustomer;
        private ClassCustomer _editOrNewCustomer;
        private ClassOrder _order;
        private bool _isEnabled;

        public ClassBiz()
        {
            // Få alle verdier fra web api
            apiRates = Task.Run(async () => await GetApiRates()).ConfigureAwait(false).GetAwaiter().GetResult();

            listCustomer = new List<ClassCustomer>();
            listCountry = new List<ClassCountry>();
            listMeat = new List<ClassMeat>();
            order = new ClassOrder(apiRates);
            selectedCustomer = new ClassCustomer();
            editOrNewCustomer = new ClassCustomer();
            isEnabled = true;

            listCountry = cmgdb.GetAllCountriesFromDB(apiRates);
            listCustomer = cmgdb.GetAllCustomersFromDB(apiRates);
            listMeat = cmgdb.GetAllMeatFromDB();
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
        public List<ClassCountry> listCountry
        {
            get { return _listCountry; }
            set
            {
                if (_listCountry != value)
                {
                    _listCountry = value;
                }
                Notify("listCountry");
            }
        }
        public List<ClassMeat> listMeat
        {
            get { return _listMeat; }
            set
            {
                if (_listMeat != value)
                {
                    _listMeat = value;
                }
                Notify("listMeat");
            }
        }
        public ClassApiRates apiRates
        {
            get { return _apiRates; }
            set
            {
                if (_apiRates != value)
                {
                    _apiRates = value;
                }
                Notify("apiRates");
            }
        }
        public ClassCustomer selectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    order.orderCustomer = _selectedCustomer;
                }
                Notify("selectedCustomer");
            }
        }
        public ClassCustomer editOrNewCustomer
        {
            get { return _editOrNewCustomer; }
            set
            {
                if (_editOrNewCustomer != value)
                {
                    _editOrNewCustomer = value;
                }
                Notify("editOrNewCustomer");
            }
        }
        public ClassOrder order
        {
            get { return _order; }
            set
            {
                if (_order != value)
                {
                    _order = value;
                }
                Notify("order");
            }
        }
        public bool isEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                }
                Notify("isEnabled");
            }
        }

        public async Task<ClassApiRates> GetApiRates()
        {
            ClassApiRates res = new ClassApiRates();
            res = await ccwa.GetRatesFromWebApi();

            return res;
        }
        public void SetUpListCustomer()
        {

        }
        public void UpdateListCustomerAndSelectedCustomer(int newCustomerId)
        {
            List<ClassCustomer> newCustomerList = cmgdb.GetAllCustomersFromDB(apiRates);
            ClassCustomer newSelectedCustomer = new ClassCustomer();

            foreach (ClassCustomer cc in newCustomerList)
            {
                if (cc.id == selectedCustomer.id || cc.id == newCustomerId)
                {
                    newSelectedCustomer = cc;
                    break;
                }
            }

            listCustomer = newCustomerList;
            selectedCustomer = newSelectedCustomer;
        }
        public int SaveCustomer()
        {
            int res = 0;

            foreach (ClassCustomer cc in listCustomer)
            {
                if (cc.id == selectedCustomer.id)
                {
                    cmgdb.UpdateCustomerInDB(selectedCustomer);
                    return res;
                }
            }

            return cmgdb.SaveNewCustomerInDB(selectedCustomer);
        }
        public void SaveSaleInDB()
        {

        }
        public void SaveNewMeatPrice(string inMeat, double inPrice, int inWeight)
        {

        }
    }
}
