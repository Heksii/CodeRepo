using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class Main : ClassNotify
    {
        private double _temp;
        private int _pressure;
        private int _humidity;

        public Main()
        {
            temp = 0D;
            pressure = 0;
            humidity = 0;
        }

        public int humidity
        {
            get { return _humidity; }
            set
            {
                if (_humidity != value)
                {
                    _humidity = value;
                }
                Notify("humidity");
            }
        }
        public int pressure
        {
            get { return _pressure; }
            set
            {
                if (_pressure != value)
                {
                    _pressure = value;
                }
                Notify("pressure");
            }
        }
        public double temp
        {
            get { return _temp; }
            set
            {
                if (_temp != value - 273.15)
                {
                    _temp = Math.Round(value - 273.15, 2);
                }
                Notify("temp");
            }
        }
    }
}
