using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class Coord : ClassNotify
    {
        private double _lat;
        private double _lon;

        public Coord()
        {
            lat = 0D;
            lon = 0D;
        }

        public double lon
        {
            get { return _lon; }
            set
            {
                if (_lon != value)
                {
                    _lon = value;
                }
                Notify("lon");
            }
        }
        public double lat
        {
            get { return _lat; }
            set
            {
                if (_lat != value)
                {
                    _lat = value;
                }
                Notify("lat");
            }
        }
    }
}