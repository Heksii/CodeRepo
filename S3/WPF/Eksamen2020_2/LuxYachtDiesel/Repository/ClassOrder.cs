using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassOrder : ClassNotify
    {
        #region Private Fields

        private ClassCustomer _customer;

        private double _customerRate;

        private DateTime _date;

        private double _ownProfit;

        private double _price;

        private ClassSupplier _supplier;

        private double _supplierRate;

        private int _volume;

        #endregion Private Fields

        #region Public Constructors

        public ClassOrder()
        {
            customer = new ClassCustomer();
            customerRate = 0D;
            date = new DateTime();
            ownProfit = 0D;
            price = 0D;
            supplier = new ClassSupplier();
            supplierRate = 0D;
            volume = 0;
        }

        #endregion Public Constructors

        #region Public Properties

        public ClassCustomer customer
        {
            get
            {
                return _customer;
            }
            set
            {
                if (_customer != value)
                {
                    _customer = value;
                }
                Notify("customer");
            }
        }

        public double customerRate
        {
            get
            {
                return _customerRate;
            }
            set
            {
                if (_customerRate != value)
                {
                    _customerRate = value;
                }
                Notify("customerRate");
            }
        }

        public DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                if (_date != value)
                {
                    _date = value;
                }
                Notify("date");
            }
        }

        public double ownProfit
        {
            get
            {
                return _ownProfit;
            }
            set
            {
                if (_ownProfit != value)
                {
                    _ownProfit = value;
                }
                Notify("ownProfit");
            }
        }

        public double price
        {
            get
            {
                return _price;
            }
            set
            {
                if (_price != value)
                {
                    _price = value;
                }
                Notify("price");
            }
        }

        public ClassSupplier supplier
        {
            get
            {
                return _supplier;
            }
            set
            {
                if (_supplier != value)
                {
                    _supplier = value;
                }
                Notify("supplier");
            }
        }

        public double supplierRate
        {
            get
            {
                return _supplierRate;
            }
            set
            {
                if (_supplierRate != value)
                {
                    _supplierRate = value;
                }
                Notify("supplierRate");
            }
        }

        public int volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (_volume != value)
                {
                    _volume = value;
                }
                Notify("volume");
            }
        }

        #endregion Public Properties
    }
}