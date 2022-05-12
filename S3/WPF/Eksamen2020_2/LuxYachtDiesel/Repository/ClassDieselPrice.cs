using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassDieselPrice : ClassNotify
    {
        #region Private Fields

        private DateTime _date;

        private int _Id;

        private double _price;

        #endregion Private Fields

        #region Public Constructors

        public ClassDieselPrice()
        {
            Id = 0;
            date = new DateTime();
            price = 0.0D;
        }

        #endregion Public Constructors

        #region Public Properties

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

        #endregion Public Properties
    }
}