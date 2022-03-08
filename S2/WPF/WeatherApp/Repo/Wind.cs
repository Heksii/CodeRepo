using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Repo
{
    public class Wind : ClassNotify
    {
        private double _speed;
        private int _deg;
        private string _windName;

        public Wind()
        {
            deg = 0;
            speed = 0D;
        }

        public string windName
        {
            get { return _windName; }
            set
            {
                if (_windName != value)
                {
                    _windName = value;
                }
                Notify("windName");
            }
        }
        public int deg
        {
            get { return _deg; }
            set
            {
                if (_deg != value)
                {
                    _deg = value;
                    windName = WindNameFromDegrees(value);
                }
                Notify("deg");
            }
        }
        public double speed
        {
            get { return _speed; }
            set
            {
                if (_speed != value)
                {
                    _speed = value;
                }
                Notify("speed");
            }
        }
    
        string WindNameFromDegrees(int degrees)
        {
            List<string> directionNames = new List<string>()
            {
                "Nord",
                "Nord-nordøst",
                "Nordøst",
                "Øst-nordøst",
                "Øst",
                "Øst-sydøst",
                "Sydøst",
                "Syd-sydøst",
                "Syd",
                "Syd-sydvest",
                "Sydvest",
                "Vest-sydvest",
                "Vest",
                "Vest-nordvest",
                "Nordvest",
                "Nord-nordvest"
            };

            int listIndex = (int)(degrees / 22.5);
            return directionNames[listIndex];
        }
    }
}
