using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    /// <summary>
    /// En klasse der er ansvarlig for at dekryptere tekst krypteret med rolling encryption
    /// </summary>
    public class ClassRollingDecrypt
    {
        private List<string> keyList = new List<string>();

        public ClassRollingDecrypt(string[] inKey)
        {
            MakeCharList(inKey);
        }

        /// <summary>
        /// En metode ansvarlig for at dekryptere teksten,
        /// den gør det ved at lede efter chars i inString som også er i den valgte krypteringsnøgle
        /// og bruger en metode i klassen som laver en character der er del af den dekrypteret besked
        /// fra et lille stykke af den krypteret tekst.
        /// 
        /// Alt andet dummy tekst bliver sprunget over.
        /// </summary>
        /// <param name="inString">string</param>
        /// <returns>string</returns>
        public string DecryptString(string inString)
        {
            int offset = 0;
            string res = "";
            string tempRes = "";

            Encoding enc1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252);
            byte[] asciiBytes = enc1252.GetBytes(inString);

            foreach (char asciiNum in asciiBytes)
            {
                if (keyList.Contains(asciiNum.ToString()))
                {
                    tempRes += asciiNum.ToString();
                }
                else
                {
                    if (tempRes != "")
                    {
                        res += MakeCharFromCode(tempRes, offset);
                        tempRes = "";
                        offset = 1;
                    }
                    else
                    {
                        offset++;
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// En privat metode der laver et lille stykke af noget krypteret 
        /// tekst om til et bogstav der hører til det dekrypteret tekst.
        /// </summary>
        /// <param name="inCharString">string</param>
        /// <returns>string</returns>
        private string MakeCharFromCode(string inCharString, int offset)
        {
            string newIndex = "";
            int localOffset = 1;

            foreach (char inChar in inCharString)
            {
                int intChar = keyList.IndexOf(inChar.ToString());
                intChar = GetRealKey(intChar, (offset + localOffset));
                localOffset += 3;
                newIndex += intChar.ToString();
            }

            return $"{(char)Convert.ToInt32(newIndex)}";
        }

        /// <summary>
        /// En metode der returnere en verdi der altid er imellem 0 og 9
        /// så vi er sikre på at man kan indexe keyList med den.
        /// </summary>
        /// <param name="inValue">int</param>
        /// <param name="inOffset">int</param>
        /// <returns>int</returns>
        private int GetRealKey(int inValue, int inOffset)
        {
            int res = inValue - inOffset;

            while (res > 9 || res < 0) // Loop der kører hvis res ikke er imellem 0 og 9.
            {
                res += (res > 9 ? -10 : 10); // Hvis res er størrer end 9 så trækkes 10 fra res,
                                             // Ellers kan res kun være under 0 og så ligges der 10 til res.
            }

            return res;
        }
        
        /// <summary>
        /// En metode der kommer alle elementer tilhørende et array af 
        /// strings ind i en liste.
        /// </summary>
        /// <param name="strings">string[]</param>
        private void MakeCharList(string[] strings)
        {
            foreach (string item in strings)
            {
                keyList.Add(item);
            }
        }
    }
}
