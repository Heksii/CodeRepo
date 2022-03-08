using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCountry : ClassNotify
    {
        

        private string _code;
        private string _countryName;
        private string _valutaName;
        private int _id;

        public ClassCountry(ClassCountry inCountry)
        {
            id = inCountry.id;
            countryName = inCountry.countryName;
            code = inCountry.code;
            valutaName = inCountry.valutaName;
        }

        public ClassCountry()
        {
            id = 0;
            countryName = "";
            code = "";
            valutaName = "";
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
        public string valutaName
        {
            get { return $"{_valutaName} ({_countryName})"; }
            set
            {
                if (_valutaName != value)
                {
                    _valutaName = value;
                }
                Notify("valutaName");
            }
        }
        public string countryName
        {
            get { return _countryName; }
            set
            {
                if (_countryName != value)
                {
                    _countryName = value;
                }
                Notify("countryName");
            }
        }
        public string code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                }
                Notify("code");
            }
        }
    }
}
