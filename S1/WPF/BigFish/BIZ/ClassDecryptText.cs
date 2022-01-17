using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    /// <summary>
    /// En klasse der er ansvarlig for at dekryptere den krypteret tekst.
    /// </summary>
    public class ClassDecryptText
    {
        private List<string> keyList = new List<string>();

        /// <summary>
        /// En overloaded constructor der kalder en metode inden i klassen som konvertere
        /// et array af chars til en liste af strings.
        /// </summary>
        /// <param name="decryptKey"></param>
        public ClassDecryptText(string[] decryptKey)
        {
            MakeCharList(decryptKey);
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
                        res += MakeCharFromCode(tempRes);
                        tempRes = "";
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
        private string MakeCharFromCode(string inCharString)
        {
            string res = "";
            string tempRes = "";

            foreach (char inChar in inCharString)
            {
                int intChar = keyList.IndexOf(inChar.ToString());
                tempRes += intChar.ToString();
            }

            res = $"{(char)Convert.ToInt32(tempRes)}";
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
