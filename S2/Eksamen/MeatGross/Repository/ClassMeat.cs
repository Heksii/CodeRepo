using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Denne class har ansvaret for at holde på data om et kød produkt.
    /// </summary>
    public class ClassMeat : ClassNotify
    {
        private int _id;
        private string _typeOfMeat;
        private string _stock;
        private double _pricePerKG;
        private DateTime _pricePerKGTimestamp;
        private string _strTimestamp;

        public ClassMeat()
        {
            id = 0;
            typeOfMeat = "";
            stock = "";
            pricePerKG = 0D;
            pricePerKGTimestamp = DateTime.Now;
            strTimestamp = "";
        }

        public string strTimestamp
        {
            get { return _strTimestamp; }
            set
            {
                if (_strTimestamp != value)
                {
                    _strTimestamp = value;
                }
                Notify("strTimestamp");
            }
        }
        public DateTime pricePerKGTimestamp
        {
            get { return _pricePerKGTimestamp; }
            set
            {
                if (_pricePerKGTimestamp != value)
                {
                    _pricePerKGTimestamp = value;
                }
                Notify("pricePerKGTimestamp");
            }
        }
        public double pricePerKG
        {
            get { return _pricePerKG; }
            set
            {
                if (_pricePerKG != value)
                {
                    _pricePerKG = value;
                }
                Notify("pricePerKG");
            }
        }
        public string stock
        {
            get { return _stock; }
            set
            {
                if (_stock != value)
                {
                    _stock = value;
                }
                Notify("stock");
            }
        }
        public string typeOfMeat
        {
            get { return _typeOfMeat; }
            set
            {
                if (_typeOfMeat != value)
                {
                    _typeOfMeat = value;
                }
                Notify("typeOfMeat");
            }
        }
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
                Notify("id");
            }
        }
    }
}
