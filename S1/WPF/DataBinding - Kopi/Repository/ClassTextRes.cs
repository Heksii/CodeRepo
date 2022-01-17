using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Class for getting the text for the bottom half of the window from the input box.
    /// </summary>
    public class ClassTextRes : ClassNotify
    {
        public ClassTextRes()
        {
            strTextRes = "Indtast et heltal - Og du får et resultat !";
        }

        private string _strTextRes;

        public string strTextRes
        {
            get { return _strTextRes; }
            private set
            {
                if (_strTextRes != value)
                {
                    _strTextRes = value;
                }
                
                Notify("strTextRes");
            }
        }

        /// <summary>
        /// Sets strTextRes in ClassTextRes to "Tallet {num} er et {(num % 2 == 0 ? "LIGE" : "ULIGE")} tal."
        /// </summary>
        /// <param name="num"></param>
        public void IsNumberEven(long num)
        {
            strTextRes = $"Tallet {num} er et {(num % 2 == 0 ? "LIGE" : "ULIGE")} tal.";
        }
    }
}
