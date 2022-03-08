using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Repository;

namespace BIZ
{
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
            _listCustomer = new List<ClassCustomer>();
            _listCountry = new List<ClassCountry>();
            _listMeat = new List<ClassMeat>();
            _apiRates = new ClassApiRates();
            _selectedCustomer = new ClassCustomer();
            _editOrNewCustomer = new ClassCustomer();
            _isEnabled = false;
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

            return res;
        }
        public void SetUpListCustomer()
        {

        }
        public void UpdateListCustomer()
        {

        }
        public int SaveNewCustomer()
        {
            int res = 0;




            return res;
        }
        public void UpdateCustomer()
        {

        }
        public void SaveSaleInDB()
        {

        }
        public void SaveNewMeatPrice(string inMeat, double inPrice, int inWeight)
        {

        }

        private void SetUpListCountry()
        {

        }
    }
}
