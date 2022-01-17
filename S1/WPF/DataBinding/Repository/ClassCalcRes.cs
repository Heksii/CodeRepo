using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Class for calculating the text needed to be shown from the input text.
    /// </summary>
    public class ClassCalcRes : ClassNotify
    {
        private string _strCalcNumber;
        private string _strCalcRes;
        private ClassTextRes _textRes;

        public ClassCalcRes()
        {
            textRes = new ClassTextRes();
            strCalcRes = "0";
            strCalcNumber = "0";
        }

        public string strCalcRes
        {
            get { return _strCalcRes; }
            private set
            {
                if (_strCalcRes != value)
                {
                    _strCalcRes = value;
                    long.TryParse(_strCalcRes, out long num);
                    textRes.IsNumberEven(num);
                }
                Notify("strCalcRes");
            }
        }

        public string strCalcNumber
        {
            get { return _strCalcNumber; }
            set
            {
                if (_strCalcNumber != value)
                {
                    _strCalcNumber = value;
                    CalcNumber(value);
                }
                Notify("strCalcNumber");
            }
        }

        public ClassTextRes textRes
        {
            get { return _textRes; }
            set
            {
                if (_textRes != value)
                {
                    _textRes = value;
                }
                Notify("textRes");
            }
        }
        
        /// <summary>
        /// Sets strCalcRes inside ClassCalcRes to the number from the input box * 1387.
        /// </summary>
        /// <param name="strNumber"></param>
        private void CalcNumber(string strNumber)
        {
            long number = 0;
            if (strNumber != null)
            {
                long.TryParse(strNumber, out number);
                number *= 1387;
            }
            
            strCalcRes = number.ToString();
        }
    }
}
