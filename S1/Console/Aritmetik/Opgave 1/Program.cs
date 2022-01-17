using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "12";
            string str2 = "34";

            int int1 = 12;
            int int2 = 34;

            string strResult = str1 + str2;
            int intResult = int1 + int2;
            string intStrResult = str1 + int1;

            Console.WriteLine($"Tekst lagt sammen er: {strResult}");
            Console.WriteLine($"Tal lagt sammen er: {intResult}");
            Console.WriteLine($"Tekst og tal lagt sammen er: {intStrResult}");

            Console.ReadLine();
        }
    }
}
