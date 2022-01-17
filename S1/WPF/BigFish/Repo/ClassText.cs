using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    /// <summary>
    /// En klasse der ansvarlig for at kunne
    /// bruge data binding på de TextBoxes i GUI.
    /// </summary>
    public class ClassText : ClassNotify
    {
        private string _tekst;

        public ClassText()
        {
            tekst = "";
        }

        public string tekst
        {
            get { return _tekst; }
            set
            {
                if (_tekst != value)
                {
                    _tekst = value;
                }
                Notify("tekst");
            }
        }
    }
}
