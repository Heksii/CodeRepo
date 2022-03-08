using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class Weather : ClassNotify
    {
        private string _description;
        private string _icon;

        public Weather()
        {
            description = "";
            icon = "";
        }

        public string icon
        {
            get { return $"https://openweathermap.org/img/w/{_icon}.png"; }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                }
                Notify("icon");
            }
        }
        public string description
        {
            get { return _description.Substring(0, 1).ToUpper() + _description.Substring(1).ToLower(); }
            set
            {
                if (_description != value)
                {
                    _description = value;
                }
                Notify("description");
            }
        }
    }
}
