using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    /// <summary>
    /// En klasse der er ansvarlig for at kryptere tekst med rolling encryption.
    /// </summary>
    public class ClassRollingEncrypt
    {
        private string[] key;
        ClassDummyText cdt;

        /// <summary>
        /// En overloaded constructor der kalder en metode inden i klassen som konvertere
        /// et array af chars til en liste af strings og initialisere en instans af ClassDummyText.
        /// </summary>
        /// <param name="decryptKey"></param>
        public ClassRollingEncrypt(string[] inKey, string[] inDummy)
        {
            key = inKey;
            cdt = new ClassDummyText(inDummy);
        }

        /// <summary>
        /// Den primære metode til klassen som er ansvarlig for at kryptere teksten (inString)
        /// med rolling encryption ved at lave alt teksten om til små grupper af karakterer fra 
        /// krypteringsnøglen og komme dummy tekst ind i mellem.
        /// </summary>
        /// <param name="inString">string</param>
        /// <returns>string</returns>
        public string EncryptString(string inString)
        {
            string res = "";
            string tempDummy = "";
            int offset = 0;

            Encoding enc1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);
            byte[] asciiBytes = enc1252.GetBytes(inString);

            res = cdt.MakeDummyString();
            offset = res.Length;

            foreach (char asciiNum in asciiBytes)
            {
                res += EncryptChar(asciiNum, offset);
                tempDummy = cdt.MakeDummyString();
                offset = tempDummy.Length;
                res += tempDummy;
            }

            return res;
        }

        /// <summary>
        /// En metode der tager en character som parameter og returnere 
        /// en string der indeholder karaktere fra krypteringsnøglen 
        /// baseret på cifrerne i talværdien af den karakter og offset parametren.
        /// </summary>
        /// <param name="inChar">char</param>
        /// <param name="offset">int</param>
        /// <returns>string</returns>
        private string EncryptChar(char inChar, int offset)
        {
            string res = "";
            int localOffset = 1;
            int intChar = inChar;
            string strChar = intChar.ToString();

            foreach (char numChar in strChar)
            {
                string charString = numChar.ToString();
                int charInt = Convert.ToInt32(charString);

                charInt = GetRollingKey(charInt, (offset + localOffset));
                res += key[charInt];
                localOffset += 3;
            }

            return res;
        }

        /// <summary>
        /// En metode returnere en verdi mellem 0 og 9 med hjælp af modulus.
        /// </summary>
        /// <param name="inValue">int</param>
        /// <param name="inOffset">int</param>
        /// <returns>int</returns>
        private int GetRollingKey(int inValue, int inOffset)
        {
            return (inValue + inOffset) % 10;
        }
    }
}
