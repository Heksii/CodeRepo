using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        /// <summary>
        /// Class for the business layer of the program.
        /// </summary>
        public ClassBIZ()
        {
            calcRes = new ClassCalcRes();
        }

        private ClassCalcRes _calcRes;

        public ClassCalcRes calcRes
        {
            get { return _calcRes; }
            set
            {
                if (_calcRes != value)
                {
                    _calcRes = value;
                }
            }
        }
    }
}
