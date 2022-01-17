using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    /// <summary>
    /// En klasse der er ansvarlig for at kryptere tekst.
    /// </summary>
    public class ClassEncryptText
    {
        ClassDummyText dummyText;
        private string[] key;

        /// <summary>
        /// En overloaded constructor der initialisere krypteringsnøglen og dummy karakterene.
        /// </summary>
        /// <param name="inKey">string[]</param>
        /// <param name="inDummy">string[]</param>
        public ClassEncryptText(string[] inKey, string[] inDummy)
        {
            key = inKey;
            dummyText = new ClassDummyText(inDummy);
        }

        /// <summary>
        /// Den primære metode til klassen som er ansvarlig for at kryptere teksten (inString)
        /// ved at lave alt teksten om til små grupper af karakterer fra 
        /// krypteringsnøglen og komme dummy tekst ind i mellem.
        /// </summary>
        /// <param name="inString">string</param>
        /// <returns>string</returns>
        public string EncryptString(string inString)
        {
            string res = "";
            Encoding enc1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);
            byte[] asciiBytes = enc1252.GetBytes(inString);

            res = dummyText.MakeDummyString();

            foreach (char asciiNum in asciiBytes) 
            {
                string dummy = dummyText.MakeDummyString();
                res += EncryptChar(asciiNum);
                res += dummy;
            }

            return res;
        }

        /// <summary>
        /// En metode der tager en character som parameter og returnere 
        /// en string der indeholder karaktere fra krypteringsnøglen 
        /// baseret på cifrerne i talværdien af den karakter.
        /// </summary>
        /// <param name="inChar">char</param>
        /// <returns>string</returns>
        private string EncryptChar(char inChar)
        {
            string res = "";
            int charNum = inChar;
            string charNumStr = charNum.ToString();

            foreach (char digit in charNumStr)
            {
                int charInt = Convert.ToInt32(digit.ToString());
                res += key[charInt];
            }

            return res;
        }
    }
}
