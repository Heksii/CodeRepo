using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    /// <summary>
    /// En klasse der er ansvarlig for at lave dummy tekst bare
    /// for at forvirre dem der prøver at dekryptere teksten.
    /// </summary>
    public class ClassDummyText
    {
        string[] dummyArray;
        Random rnd = new Random();

        /// <summary>
        /// En constructor der ikke bliver brugt i programmet,
        /// den sætter dummyArray til en standard tabel af strings.
        /// </summary>
        public ClassDummyText()
        {
            dummyArray = new string[] { "A", "B", "C", "#", "F", "G", "H", "¤", "I", "J",
                                        "L", "P", "Q", "!", "V", "W", "X", "&", "{", "]" };
        }

        /// <summary>
        /// En overloaded constructor der acceptere et array af strings
        /// og laver dummyArray om til det array den får.
        /// </summary>
        /// <param name="inDummyArray">string[]</param>
        public ClassDummyText(string[] inDummyArray)
        {
            dummyArray = inDummyArray;
        }

        /// <summary>
        /// En metode der laver en string som består af 2-10 tilfældige
        /// tægn fra arrayet af dummy characters.
        /// </summary>
        /// <returns>string</returns>
        public string MakeDummyString()
        {
            string res = "";
            int x = rnd.Next(200, 1001) / 100;

            for (int i = 0; i < x; i++)
            {
                int n = rnd.Next(0, dummyArray.Length);
                res += dummyArray[n];
            }

            return res;
        }
    }
}
